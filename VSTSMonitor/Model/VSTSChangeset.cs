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
                Set(ref _ChangesetId, value, RaisePropertyChanged());
            }
        }
        public string Author
        {
            get { return _Author; }
            set
            {
                Set(ref _Author, value, RaisePropertyChanged());
            }
        }
        public string CheckedInBy
        {
            get { return _CheckedInBy; }
            set
            {
                Set(ref _CheckedInBy, value, RaisePropertyChanged());
            }
        }
        public string Comment
        {
            get { return _Comment; }
            set
            {
                Set(ref _Comment, value, RaisePropertyChanged());
            }
        }
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set
            {
                Set(ref _CreatedDate, value, RaisePropertyChanged());
            }
        }
        public string Url
        {
            get { return _Url; }
            set
            {
                Set(ref _Url, value, RaisePropertyChanged());
            }
        }
        public string WorkItem
        {
            get { return _WorkItem; }
            set
            {
                Set(ref _WorkItem, value, RaisePropertyChanged());
            }
        }
        public List<AssociatedWorkItem> Workitems
        {
            get { return _Workitems; }
            set
            {
                Set(ref _Workitems, value, RaisePropertyChanged());
            }
        }

        public VSTSChangeset()
        {

        }
    }
}
