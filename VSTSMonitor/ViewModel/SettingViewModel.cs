using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSTSMonitor.Command;
using VSTSMonitor.Model;
using VSTSMonitor.Setting;
using VSTSMonitor.View;

namespace VSTSMonitor.ViewModel
{
    public class SettingViewModel : ViewModelBase
    {
        private ITFService _tfsService;
        private readonly DelegateCommand<object> _VerifyConnectionCommand;
        private string _VSTSUrl;
        private string _VSTSProjectName;
        private string _VSTSUsername;
        private string _VSTSPassword;
        private string _ConnVerificationStatus = "";

        public DelegateCommand<object> VerifyConnectionCommand
        {
            get { return _VerifyConnectionCommand; }
        }
        public string VSTSUrl
        {
            get { return _VSTSUrl; }
            set { Set<string>(ref _VSTSUrl, value); }
        }
        public string VSTSProjectName
        {
            get { return _VSTSProjectName; }
            set { Set<string>(ref _VSTSProjectName, value); }
        }
        public string VSTSUsername
        {
            get { return _VSTSUsername; }
            set { Set<string>(ref _VSTSUsername, value); }
        }
        public string VSTSPassword
        {
            get { return _VSTSPassword; }
            set { Set<string>(ref _VSTSPassword, value); }
        }
        public string ConnVerificationStatus
        {
            get { return _ConnVerificationStatus; }
            set { Set<string>(ref _ConnVerificationStatus, value); }
        }

        public SettingViewModel(ITFService tfsService, SystemMessenger sysMessenger)
            : base(sysMessenger)
        {
            _tfsService = tfsService;
            _VerifyConnectionCommand = new DelegateCommand<object>(VerifyConnectionCommand_Execute, VerifyConnectionCommand_CanExecute);
            _VSTSUrl = UserSetting.TFSCollectionUri;
            _VSTSProjectName = UserSetting.TFSProjectName;
            _VSTSUsername = UserSetting.TFSUsername;
            _VSTSPassword = UserSetting.TFSPassword;

            PropertyChanged += SettingViewModel_PropertyChanged;
        }

        private void SettingViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "VSTSUrl")
                UserSetting.TFSCollectionUri = VSTSUrl;

            if (e.PropertyName == "VSTSProjectName")
                UserSetting.TFSProjectName = VSTSProjectName;

            if (e.PropertyName == "VSTSUsername")
                UserSetting.TFSUsername = VSTSUsername;

            if (e.PropertyName == "VSTSPassword")
                UserSetting.TFSPassword = VSTSPassword;
        }

        public async void VerifyConnectionCommand_Execute(object arg)
        {
            MessengerInstance.Send<LoadingMessage>(new LoadingMessage(LoadingScreenBehavior.Show, "Loading ..."));

            bool ConnectionSuccess = await _tfsService.ConnectAsync();

            if (ConnectionSuccess)
                ConnVerificationStatus = "Connected";
            else
                ConnVerificationStatus = "Unable to connect";

            MessengerInstance.Send<LoadingMessage>(new LoadingMessage(LoadingScreenBehavior.Hide, "Done"));
        }
        public bool VerifyConnectionCommand_CanExecute(object arg)
        {
            return true;
        }
    }
}
