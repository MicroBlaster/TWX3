using System.Collections.Generic;
using System.Windows;

namespace TWXP
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private Scripts scripts;
        private Commands cmdref;

        public Main()
        {
            InitializeComponent();

            Initialize();


            this.Hide();

            Window welcome = new Windows.Welcome();
            welcome.ShowDialog();

            Window setup = new Windows.Setup();
            setup.ShowDialog();

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



        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            List<string> ts = new List<string>();
            input.Text = "setVar $var 7\nadd $var 3 *\necho \"7 plus 3 equals\" $var *";
        

            scripts.Compile(input.Text, output);

        }
    }
}
