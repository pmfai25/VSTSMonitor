using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTSMonitor.Model
{
    public class TreeViewItem
    {
        public string ChangeType { get; set; }

        public int Level
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public List<TreeViewItem> SubItems
        {
            get;
            set;
        }
    }
}
