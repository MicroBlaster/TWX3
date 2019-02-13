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
    /// Interaction logic for License.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void LicenseLinkClick(object sender, MouseButtonEventArgs e)
        {
            Window license = new Windows.License();
            license.ShowDialog();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
