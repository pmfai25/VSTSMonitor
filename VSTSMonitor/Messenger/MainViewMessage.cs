using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTSMonitor
{
    public class MainViewMessage: MessageBase
    {
        public string ChangeToPage { get; set; }

        public MainViewMessage(string changeToPage)
        {
            ChangeToPage = changeToPage;
        }
    }
}
