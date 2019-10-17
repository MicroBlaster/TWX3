using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace TWXP
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private Scripts scripts;

        public Main()
        {
            InitializeComponent();

            Initialize();


            //this.Hide();

            //Window welcome = new Windows.Welcome();
            //welcome.ShowDialog();

            Window setup = new Windows.Setup();
            setup.ShowDialog();

            //Proxy proxy = new Proxy();
            //proxy.StartAsync();

            //this.Close();
        }

        private void Initialize()
        {
            scripts = new Scripts();

            //System.Windows.Forms.NotifyIcon icon = new System.Windows.Forms.NotifyIcon();
            //Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/YourReferencedAssembly;component/YourPossibleSubFolder/YourResourceFile.ico")).Stream;
            //icon.Icon = new System.Drawing.Icon(iconStream);



        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = new List<string>();
            input.Text = "setVar $var 7\nadd $var 3 *\necho \"7 plus 3 equals\" $var *";
        

            scripts.Compile(input.Text, output);

        }
    }
}
