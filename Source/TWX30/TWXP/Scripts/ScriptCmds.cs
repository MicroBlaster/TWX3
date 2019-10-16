using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum ScriptCmdType { Internal, Operator, Public, System };


    public partial class ScriptCmds : List<ScriptCmd>
    {
        //public delegate void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ScriptCmds()
        {

        }
    }

    public class ScriptCmd
    {
        public Parameters Parameters { get; private set; }

        // Public Read-only Properties
        public Script Script { get; private set; }

        /// <summary>
        /// Creates a new ScriptCmd.
        /// </summary>
        /// <param name="name">The name of the ScriptCmd.</param>
        /// <param name="silent">Run ScriptCmd in silent mode.</param>
        public ScriptCmd(Script script, Parameters parameters)
        {
            Script = script;
            Parameters = parameters;
        }
    }
}
