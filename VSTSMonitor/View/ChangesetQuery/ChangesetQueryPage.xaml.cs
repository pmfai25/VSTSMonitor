using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Documents;

namespace VSTSMonitor.View
{
    /// <summary>
    /// Interaction logic for ChangesetQueryPage.xaml
    /// </summary>
    public partial class ChangesetQueryPage : UserControl
    {
        public ChangesetQueryPage()
        {
            InitializeComponent();
            Messenger.Default.Register<GenericMessage<int>>(this, Notify);
        }

        public void Notify(GenericMessage<int> arg)
        {
            ChangeDetailWindow changeDetailWin = new ChangeDetailWindow();
            changeDetailWin.Show();
            changeDetailWin.SetChangesetId(arg.Content);

        }

        private void Hyperlink_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Hyperlink hyperlink = (Hyperlink)sender;
                System.Diagnostics.Process.Start(hyperlink.NavigateUri.ToString());
            }
            catch { }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;

        }
    }
}
