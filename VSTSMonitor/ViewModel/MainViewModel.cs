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
        private Visibility _LoadingScreenVisibility = Visibility.Collapsed;

        public Visibility LoadingScreenVisibility
        {
            get { return _LoadingScreenVisibility; }
            set { Set<Visibility>(ref _LoadingScreenVisibility, value); }
        }

        public MainViewModel(SystemMessenger sysMessenger)
            : base(sysMessenger)
        {
            MessengerInstance.Register<LoadingMessage>(this, NotifyMe);
        }

        public void NotifyMe(LoadingMessage message)
        {
            if (message.Behavior == LoadingScreenBehavior.Show)
                LoadingScreenVisibility = Visibility.Visible;
            else
                LoadingScreenVisibility = Visibility.Collapsed;
        }
    }
}
