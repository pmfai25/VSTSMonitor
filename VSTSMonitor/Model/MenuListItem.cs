using System;
using System.ComponentModel;

namespace VSTSMonitor.Model
{
    public class MenuListItem : ModelBase
    {
        private object _content;
        private string _name;

        public object Content
        {
            get { return _content; }
            set
            {
                Set(ref _content, value, RaisePropertyChanged());
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                Set(ref _name, value, RaisePropertyChanged());
            }
        }
    }
}