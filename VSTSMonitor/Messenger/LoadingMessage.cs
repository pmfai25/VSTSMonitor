using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTSMonitor
{
    public enum LoadingScreenBehavior
    {
        Show,
        Hide,
        GracefullyDisappear
    }

    public class LoadingMessage: MessageBase
    {
        public LoadingScreenBehavior Behavior { get; set; }
        public string Content { get; set; }

        public LoadingMessage(LoadingScreenBehavior behavior, string content)
        {
            Behavior = behavior;
            Content = content;
        }
    }
}
