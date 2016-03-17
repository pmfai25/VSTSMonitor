using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTSMonitor.Model
{
    public class VSTSChange : ModelBase
    {
        private string _ChangeType;
        private string _FilePath;

        public string ChangeType
        {
            get { return _ChangeType; }
            set
            {
                _ChangeType = value;
                NotifyPropertyChanged("ChangeType");
            }
        }
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                NotifyPropertyChanged("FilePath");
            }
        }
    }
}
