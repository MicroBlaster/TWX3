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
        private CommandReferences cmdref;

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
            //cmdref = new CommandReferences();



            //cmdref.Exec(new string[] { "setVar", "$var", "7" });
            //cmdref.Exec(new string[] { "add", "$var", "3" });
            //cmdref.Exec(new string[] { "echo", "Hello World ", "$var" });

            //string s = commands.Exec(new string[] { "CURRENTLINE" });

            List<string> ts = new List<string>();
            ts.Add("setVar $var 7");
            ts.Add("add $var 3 *");
            ts.Add("echo \"7 plus 3 equals\" $var *");

            scripts.CompileFromStrings(new Script("test.ts", true), ts);


        }
    }
}
