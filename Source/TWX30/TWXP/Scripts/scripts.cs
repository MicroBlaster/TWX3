using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum CommandType { Internal, Operator, Public, System };


    public partial class Scripts : List<Script>
    {


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Scripts()
        {

        }

        /// <summary>
        /// Executes a script.
        /// </summary>
        /// <param name="command"></param>
        public void Load(string filename)
        {
        }

        /// <summary>
        /// Compiles a script from source in memory.
        /// </summary>
        /// <param name="command"></param>
        public void Compile(string source, System.Windows.Controls.TextBox console)
        {
            Script script = new Script("Test.ts", true, console);
            Add(script);
            CompileFromArray(script, source.Replace("\r", "").Split('\n'));
        }
    }

    public class Script
    {
        public ScriptCmds Commands { get; private set; }
        public Labels Labels { get; private set; }

        // Public Read-only Properties
        public string Name { get; private set; }
        public bool Silent { get; private set; }
        public System.Windows.Controls.TextBox Console { get; private set; }

        /// <summary>
        /// Creates a new script.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="silent">Run script in silent mode.</param>
        public Script(string name, bool silent, System.Windows.Controls.TextBox console)
        {
            Commands = new ScriptCmds();
            Labels = new Labels();

            Name = name;
            Silent = silent;
            Console = console;
        }

        public void Exec()
        {
            foreach(ScriptCmd c in Commands)
            {
                Commands CmdRef = new Commands();
                CmdRef.Invoke(this, c.Parameters);
            }
        }

        public void Echo(string s)
        {
            Console.Text += s;
        }
    }
}
