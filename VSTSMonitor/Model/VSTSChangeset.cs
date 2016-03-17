using Microsoft.TeamFoundation.SourceControl.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTSMonitor.Model
{
    public class VSTSChangeset : ModelBase
    {
        private int _ChangesetId;
        private string _Author;
        private string _CheckedInBy;
        private string _Comment;
        private DateTime _CreatedDate;
        private string _Url;
        private string _WorkItem;
        private List<AssociatedWorkItem> _Workitems;

        public int ChangesetId
        {
            get { return _ChangesetId; }
            set
            {
                _ChangesetId = value;
                NotifyPropertyChanged("ChangesetId");
            }
        }
        public string Author
        {
            get { return _Author; }
            set
            {
                _Author = value;
                NotifyPropertyChanged("Author");
            }
        }
        public string CheckedInBy
        {
            get { return _CheckedInBy; }
            set
            {
                _CheckedInBy = value;
                NotifyPropertyChanged("CheckedInBy");
            }
        }
        public string Comment
        {
            get { return _Comment; }
            set
            {
                _Comment = value;
                NotifyPropertyChanged("Comment");
            }
        }
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set
            {
                _CreatedDate = value;
                NotifyPropertyChanged("CreatedDate");
            }
        }
        public string Url
        {
            get { return _Url; }
            set
            {
                _Url = value;
                NotifyPropertyChanged("Url");
            }
        }
        public string WorkItem
        {
            get { return _WorkItem; }
            set
            {
                _WorkItem = value;
                NotifyPropertyChanged("WorkItem");
            }
        }
        public List<AssociatedWorkItem> Workitems
        {
            get { return _Workitems; }
            set
            {
                _Workitems = value;
                NotifyPropertyChanged("Workitems");
            }
        }

        public VSTSChangeset()
        {

        }
    }
}
