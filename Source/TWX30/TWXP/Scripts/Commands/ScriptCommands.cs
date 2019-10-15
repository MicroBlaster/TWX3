using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum ScriptCommandType { Internal, Operator, Public, System };


    public partial class ScriptCommands : List<ScriptCommand>
    {
        //public delegate void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ScriptCommands()
        {

        }
    }

    public class ScriptCommand
    {
        public Parameters Parameters { get; private set; }

        // Public Read-only Properties
        public Script Script { get; private set; }

        /// <summary>
        /// Creates a new ScriptCommand.
        /// </summary>
        /// <param name="name">The name of the ScriptCommand.</param>
        /// <param name="silent">Run ScriptCommand in silent mode.</param>
        public ScriptCommand(Script script, Parameters parameters)
        {
            Script = script;
            Parameters = parameters;
        }
    }
}
