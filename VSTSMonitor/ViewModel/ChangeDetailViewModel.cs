using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSTSMonitor.Model;

namespace VSTSMonitor.ViewModel
{
    public class ChangeDetailViewMode : ViewModelBase
    {
        private ITFService _tfsService;
        private int _ChangesetId;
        private List<VSTSChange> _ChangeList;
        private List<TreeViewItem> _TreeViewItem;

        public int ChangesetId
        {
            get { return _ChangesetId; }
            set
            {
                Set<int>(ref _ChangesetId, value);
            }
        }
        public List<VSTSChange> ChangeList
        {
            get { return _ChangeList; }
            set
            {
                Set<List<VSTSChange>>(ref _ChangeList, value);
            }
        }
        public List<TreeViewItem> TreeViewItem
        {
            get { return _TreeViewItem; }
            set
            {
                Set<List<TreeViewItem>>(ref _TreeViewItem, value);
            }
        }

        public List<string> test;

        public ChangeDetailViewMode(ITFService tfsService)
        {
            test = new List<string>();
            for(int i = 0; i < 10000; i++)
            {
                test.Add("#######################################");
            }

            _tfsService = tfsService;
            PropertyChanged += ChangeDetailViewMode_PropertyChanged;
        }

        private void ChangeDetailViewMode_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ChangesetId")
                GetChangeDetail();
        }

        private async void GetChangeDetail()
        {
            ChangeList = await _tfsService.GetChangesetDetails(ChangesetId);
            TreeViewItem = PopulateTreeView(ChangeList, '/');
        }

        private List<TreeViewItem> PopulateTreeView(List<VSTSChange> changes, char pathSeparator)
        {
            List<TreeViewItem> sourceCollection = new List<TreeViewItem>();
            foreach (var change in changes)
            {
                string path = change.FilePath;
                string[] fileItems = path.Split(pathSeparator);
                if (fileItems.Any())
                {

                    TreeViewItem root = sourceCollection.FirstOrDefault(x => x.Name.Equals(fileItems[0]) && x.Level.Equals(1));
                    if (root == null)
                    {
                        root = new TreeViewItem()
                        {
                            Level = 1,
                            Name = fileItems[0],
                            SubItems = new List<TreeViewItem>()
                        };
                        sourceCollection.Add(root);
                    }

                    if (fileItems.Length > 1)
                    {

                        TreeViewItem parentItem = root;
                        int level = 2;
                        for (int i = 1; i < fileItems.Length; ++i)
                        {

                            TreeViewItem subItem = parentItem.SubItems.FirstOrDefault(x => x.Name.Equals(fileItems[i]) && x.Level.Equals(level));
                            if (subItem == null)
                            {
                                subItem = new TreeViewItem()
                                {
                                    ChangeType = (i + 1 == fileItems.Length) ? string.Format("[{0}]", change.ChangeType) : null,
                                    Name = fileItems[i],
                                    Level = level,
                                    SubItems = new List<TreeViewItem>()
                                };
                                parentItem.SubItems.Add(subItem);
                            }

                            parentItem = subItem;
                            level++;
                        }
                    }
                }
            }

            return sourceCollection;
        }
    }
}
