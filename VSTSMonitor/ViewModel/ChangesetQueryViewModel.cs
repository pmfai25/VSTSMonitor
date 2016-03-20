using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using VSTSMonitor.Model;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using VSTSMonitor.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using VSTSMonitor.Helper;

namespace VSTSMonitor.ViewModel
{
    public class ChangesetQueryViewModel : ViewModelBase
    {
        const int LOAD_MORE_COUNT = 30;
        private ITFService _tfsService;
        private readonly DelegateCommand<object> _ExecuteQueryCommand;
        private readonly DelegateCommand<object> _CheckChangesetCommand;
        private readonly DelegateCommand<object> _LoadMoreCommand;
        private ObservableCollection<VSTSChangeset> _ResultChangeset;
        private VSTSChangeset _SelectedChangeset;

        public DelegateCommand<object> ExecuteQueryCommand
        {
            get { return _ExecuteQueryCommand; }
        }
        public DelegateCommand<object> CheckChangesetCommand
        {
            get { return _CheckChangesetCommand; }
        }
        public DelegateCommand<object> LoadMoreCommand
        {
            get { return _LoadMoreCommand; }
        }
        public ObservableCollection<VSTSChangeset> ResultChangeset
        {
            get { return _ResultChangeset; }
            set { Set<ObservableCollection<VSTSChangeset>>(ref _ResultChangeset, value); }
        }
        public VSTSChangeset SelectedChangeset
        {
            get { return _SelectedChangeset; }
            set { Set<VSTSChangeset>(ref _SelectedChangeset, value); }
        }

        public ChangesetQueryViewModel(ITFService tfsService, SystemMessenger sysMessenger)
            : base(sysMessenger)
        {
            _tfsService = tfsService;
            _ExecuteQueryCommand = new DelegateCommand<object>(ExecuteQueryCommand_Execute);
            _CheckChangesetCommand = new DelegateCommand<object>(CheckChangesetCommand_Execute, CheckChangesetCommand_CanExecute);
            _LoadMoreCommand = new DelegateCommand<object>(LoadMoreCommand_Execute, LoadMoreCommand_CanExecute);
            _ResultChangeset = new ObservableCollection<VSTSChangeset>();

            PropertyChanged += ChangesetQueryViewModel_PropertyChanged;
            ResultChangeset.CollectionChanged += ResultChangeset_CollectionChanged;
        }

        private void ResultChangeset_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            LoadMoreCommand.RaiseCanExecuteChanged();
        }

        private void ChangesetQueryViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedChangeset")
            {
                CheckChangesetCommand.RaiseCanExecuteChanged();
            }
        }

        public async void ExecuteQueryCommand_Execute(object arg)
        {
            ResultChangeset.Clear();
            MessengerInstance.Send<LoadingMessage>(new LoadingMessage(LoadingScreenBehavior.Show, "Loading ..."));
            ResultChangeset.AddRange(await _tfsService.GetLastestChangesetAsync(0, 10));
            MessengerInstance.Send<LoadingMessage>(new LoadingMessage(LoadingScreenBehavior.Hide, null));
        }

        public void CheckChangesetCommand_Execute(object arg)
        {
            Messenger.Default.Send<GenericMessage<int>>(new GenericMessage<int>(SelectedChangeset.ChangesetId));
        }

        public bool CheckChangesetCommand_CanExecute(object arg)
        {
            return SelectedChangeset != null;
        }

        public async void LoadMoreCommand_Execute(object arg)
        {
            MessengerInstance.Send<LoadingMessage>(new LoadingMessage(LoadingScreenBehavior.Show, "Loading ..."));
            ResultChangeset.AddRange(await _tfsService.GetLastestChangesetAsync(ResultChangeset.Count, LOAD_MORE_COUNT));
            MessengerInstance.Send<LoadingMessage>(new LoadingMessage(LoadingScreenBehavior.Hide, null));
        }

        public bool LoadMoreCommand_CanExecute(object arg)
        {
            return ResultChangeset != null && ResultChangeset.Count > 0;
        }
    }
}
