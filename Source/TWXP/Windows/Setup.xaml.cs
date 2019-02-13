using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TWXP.Windows
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Setup : Window
    {
        public Setup()
        {
            InitializeComponent();

        }

        private void WikiLinkClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/MicroBlaster/TWX3/wiki"));
        }

        private void NewButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void AboutButtonClick(object sender, RoutedEventArgs e)
        {
            Window about = new Windows.About();
            about.ShowDialog();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void DabaseComBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
