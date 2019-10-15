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

namespace TWXP
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private Scripts scripts;
        private Commands commands;

        public Main()
        {
            InitializeComponent();

            Initialize();


            //this.Hide();

            //Window welcome = new Windows.Welcome();
            //welcome.ShowDialog();

            //Window setup = new Windows.Setup();
            //setup.ShowDialog();

            //Proxy proxy = new Proxy();
            //proxy.StartAsync();

            //this.Close();
        }

        private void Initialize()
        {
            scripts = new Scripts();
            commands = new Commands();

            foreach (Command c in commands)
            {
                string Name = c.Name;
            }


            //commands.Exec(new string[] { "setVar", "$var", "7" });
            //commands.Exec(new string[] { "add", "$var", "3" });
            //commands.Exec(new string[] { "echo", "Hello World ", "$var" });

            //string s = commands.Exec(new string[] { "CURRENTLINE" });

            string ts = "setVar $var 7 *" +
                        "add $var 3 *" +
                        "echo \"7 plus 3 equals\" $var *";

            scripts.Compile(ts);

            string vb = "$var = 7 *" +
                        "$var += 3 *" +
                        "echo \"7 plus 3 equals\" $var *";

            //scripts.Compile(ts);
        }
    }
}
