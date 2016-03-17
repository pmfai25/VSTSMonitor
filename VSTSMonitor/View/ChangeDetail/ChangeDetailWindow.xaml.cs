using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VSTSMonitor.ViewModel;

namespace VSTSMonitor.View
{
    public partial class ChangeDetailWindow : Window
    {
        private string _VMInstanceKey;

        public ChangeDetailWindow()
        {
            InitializeComponent();
            _VMInstanceKey = Guid.NewGuid().ToString();
            DataContext = SimpleIoc.Default.GetInstance<ChangeDetailViewMode>(_VMInstanceKey);

            Closed += ChangeDetailWindow_Closed;
        }

        private void ChangeDetailWindow_Closed(object sender, EventArgs e)
        {
            //SimpleIoc.Default.Unregister(_VMInstanceKey);
        }

        public void SetChangesetId(int changesetId)
        {
            ChangeDetailViewMode ViewModel = (ChangeDetailViewMode)this.DataContext;
            ViewModel.ChangesetId = changesetId;
        }
    }
}
