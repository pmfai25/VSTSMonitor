using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace VSTSMonitor.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _ShowRootLoading = false;
        private int _SelectedPageIndex;

        public bool ShowRootLoading
        {
            get { return _ShowRootLoading; }
            set { Set<bool>(ref _ShowRootLoading, value); }
        }

        public int SelectedPageIndex
        {
            get { return _SelectedPageIndex; }
            set { Set<int>(ref _SelectedPageIndex, value); }
        }

        public MainViewModel(SystemMessenger sysMessenger)
            : base(sysMessenger)
        {
            _SelectedPageIndex = 0;
            MessengerInstance.Register<LoadingMessage>(this, NotifyMe);
            MessengerInstance.Register<MainViewMessage>(this, NotifyMe);
        }

        public void NotifyMe(LoadingMessage message)
        {
            if (message.Behavior == LoadingScreenBehavior.Show)
                ShowRootLoading = true;
            else
                ShowRootLoading = false;
        }

        public void NotifyMe(MainViewMessage message)
        {
            if (message.ChangeToPage == "ChangesetQuery")
                SelectedPageIndex = 0;

            if (message.ChangeToPage == "Setting")
                SelectedPageIndex = 1;
        }
    }
}
