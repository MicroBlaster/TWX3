using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum CommandType { Internal, Operator, Public, System };


    public class Scripts : List<Script>
    {
        //public delegate void voidDeligate(string[] args);


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
        public void Compile(string source)
        {
            Add(new Script("", true));

            string[] lines = source.Split('*');

            foreach(string line in lines)
            {
                //Parse(line);
               
            }
        }
    }

    public class Script
    {
        // Public Read-only Properties
        public string Name { get; private set; }
        public bool Silent { get; private set; }

        /// <summary>
        /// Creates a new script.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="silent">Run script in silent mode.</param>
        public Script(String name, bool silent)
        {
            Name = name;
            Silent = silent;
        }
    }
}
