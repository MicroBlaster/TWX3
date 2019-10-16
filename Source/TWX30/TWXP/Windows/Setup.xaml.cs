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

        private void onTreviewChange(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DatabaseGrid.Visibility = Visibility.Hidden;
            LoginGrid.Visibility = Visibility.Hidden;
            CorpGrid.Visibility = Visibility.Hidden;
            TerminalGrid.Visibility = Visibility.Hidden;
            LoggingGrid.Visibility = Visibility.Hidden;


            switch (((TreeViewItem)((TreeView)sender).SelectedItem).Header)
            {
                case "Session":

                    TreeViewItem Item1 = (TreeViewItem)((TreeViewItem)((TreeView)sender).SelectedItem).Items[0];
                    if (Item1 != null) Item1.IsSelected = true;
                    break;

                case "Database/Server":
                    DatabaseGrid.Visibility = Visibility.Visible;
                    break;

                case "Login/Identity":
                    LoginGrid.Visibility = Visibility.Visible;
                    break;

                case "Corp/Options":
                    CorpGrid.Visibility = Visibility.Visible;
                    break;

                case "Global":
                    TreeViewItem Item2 = (TreeViewItem)((TreeViewItem)((TreeView)sender).SelectedItem).Items[0];
                    if (Item2 != null) Item2.IsSelected = true;
                    break;

                case "Terminal/Remote":
                    TerminalGrid.Visibility = Visibility.Visible;
                    break;

                case "Logging/AutoRun":
                    LoggingGrid.Visibility = Visibility.Visible;
                    break;

            }
        }
        private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
    }
}
