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

        public bool ShowRootLoading
        {
            get { return _ShowRootLoading; }
            set { Set<bool>(ref _ShowRootLoading, value); }
        }

        public MainViewModel(SystemMessenger sysMessenger)
            : base(sysMessenger)
        {
            MessengerInstance.Register<LoadingMessage>(this, NotifyMe);
        }

        public void NotifyMe(LoadingMessage message)
        {
            if (message.Behavior == LoadingScreenBehavior.Show)
                ShowRootLoading = true;
            else
                ShowRootLoading = false;
        }
    }
}
