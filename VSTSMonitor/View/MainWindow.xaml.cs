using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;

namespace VSTSMonitor.View
{
    /// <summary>
    /// Interaction logic for ExplorerWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnLightTheme_Click(object sender, RoutedEventArgs e)
        {
            new PaletteHelper().SetLightDark(false);
        }

        private void btnDarkTheme_Click(object sender, RoutedEventArgs e)
        {
            new PaletteHelper().SetLightDark(true);
        }
    }
}