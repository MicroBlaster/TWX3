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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TWX.Terminal;

namespace TWXP
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();

            this.Hide();

            //Window welcome = new Windows.Welcome();
            //welcome.ShowDialog();

            //Window setup = new Windows.Setup();
            //setup.ShowDialog();

            Proxy proxy = new Proxy();
            proxy.StartAsync();

            //this.Close();
        }
    }
}
