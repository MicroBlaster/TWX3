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
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace TWXP.Windows
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Setup : Window
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int PickIconDlg(IntPtr hwndOwner, System.Text.StringBuilder lpstrFile, int nMaxFile, ref int lpdwIconIndex);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern uint ExtractIconEx(string szFileName, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        private const int MAX_PATH = 0x00000104;

        public Setup()
        {
            InitializeComponent();

            innerBorder.Visibility = Visibility.Visible;
            LoadIconPicker();
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

        private void BrowseButtonClick(object sender, RoutedEventArgs e)
        {
            // show the Pick Icon Dialog
            int index = 0;
            int retval;
            var handle = new WindowInteropHelper(this).Handle;
            var iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\shell32.dll";
            var sb = new System.Text.StringBuilder(iconfile, MAX_PATH);
            retval = PickIconDlg(handle, sb, sb.MaxCapacity, ref index);

            if (retval != 0)
            {
                // extract the icon
                //var largeIcons = new IntPtr[1];
                //var smallIcons = new IntPtr[1];
                //ExtractIconEx(sb.ToString(), index, largeIcons, smallIcons, 1);

                // convert icon handle to ImageSource
                //this.myImage.Source = Imaging.CreateBitmapSourceFromHIcon(largeIcons[0],
                //    Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                // clean up
                //DestroyIcon(largeIcons[0]);
                //DestroyIcon(smallIcons[0]);
            }

        }

        public class ListItem
        {
            public BitmapSource Source { get; set; }
            
        }

        private void LoadIconPicker()
        {
            //var iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\shell32.dll";
            //var sb = new System.Text.StringBuilder(iconfile, MAX_PATH);

            // extract the icon
            var largeIcons = new IntPtr[1];
            var smallIcons = new IntPtr[1];

            uint Integer = ExtractIconEx(@"C:\WINDOWS\SYSTEM32\shell32.dll", -1, largeIcons, smallIcons, 0);

            for (int index = 0; index < Integer; index++)
            {
                ExtractIconEx(@"C:\WINDOWS\SYSTEM32\shell32.dll", index, largeIcons, smallIcons, 1);

                TrayIconList.Items.Add(new ListItem
                {
                    Source = Imaging.CreateBitmapSourceFromHIcon(largeIcons[0],
                    Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())
                });
            }

            DestroyIcon(largeIcons[0]);
            DestroyIcon(smallIcons[0]);
        }

        private void ChooseButtonClick(object sender, RoutedEventArgs e)
        {
            TrayIconList.Visibility = Visibility.Visible;
            ChooseIcon.Visibility = Visibility.Hidden;
            BrowseIcon.Visibility = Visibility.Hidden;
        }

        private void TraIconListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ListItem SelectedItem = (ListItem)((ListView)sender).SelectedItems[0];

           int Index = TrayIconList.Items.IndexOf(SelectedItem);

           TrayIconList.Visibility = Visibility.Hidden;
            ChooseIcon.Visibility = Visibility.Visible;
            BrowseIcon.Visibility = Visibility.Visible;
        }

    }
}
