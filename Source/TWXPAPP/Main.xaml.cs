using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using TWXP;

namespace TWXPAPP
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        //private Scripts scripts;
        private Proxy proxy;

        public Proxy Proxy { get => proxy; set => proxy = value; }

        public Main()
        {
            InitializeComponent();

            Initialize();

            //proxy.Scripts.Load(@"scripts\zed-bot.vb");
            //proxy.Scripts.Load(@"scripts\zed-bot.cs");

            //this.Hide();

            //Window welcome = new Welcome();
            //welcome.ShowDialog();

            //Window setup = new Setup();
            //setup.ShowDialog();

            Proxy = new Proxy();
            _ = proxy.StartAsync();
            input.Text = proxy.Scripts.Load(@"scripts\zed-bot.cts");

            //this.Close();
        }

        private void Initialize()
        {
            //scripts = new Scripts();

            //Commands.CreateCommands();

            //System.Windows.Forms.NotifyIcon icon = new System.Windows.Forms.NotifyIcon();
            //Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/YourReferencedAssembly;component/YourPossibleSubFolder/YourResourceFile.ico")).Stream;
            //icon.Icon = new System.Drawing.Icon(iconStream);



        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            //List<string> ts = new List<string>();
            //input.Text = "setVar meow 7\nadd meow 3\necho \"7 plus 3 equals\" meow *\n" +
            //    "setvar MyVar1 True\n" +
            //    "setvar MyVar2 True\n" +
            //    "and MyVar1 MyVar2\n" +
            //    "echo \":\" MyVar1 \":\" MyVar2 \n" +
            //    "setvar $Var1 1\n" +
            //    "setvar $Var2 1\n" +
            //    "and $Var1 $Var2\n" +
            //    "echo \":\" $Var1 \":\" $Var1 \n"


            //    ;


            proxy.Scripts.Compile(input.Text);

        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (Connect.Content.ToString() == "Connect")
            {
                Connect.Content = "Disconnect";
                proxy.Connect();
            }
            else 
            {
                Connect.Content = "Connect";
                proxy.Disconnect();
            }

        }
    }
}
