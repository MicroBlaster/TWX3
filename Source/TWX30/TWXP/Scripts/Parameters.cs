using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum CommandType { Internal, Operator, Public, System };


    public partial class Parameters : List<Parameter>
    {
        //public delegate void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Parameters()
        {

        }


    }

    public class Parameter
    {
        // Public Read-only Properties
        //public string Name { get; private set; }
        public string Value { get; private set; }
        public string DecValue { get; private set; }
        public bool IsNumeric { get; private set; }

        /// <summary>
        /// Creates a new Parameter.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="silent">Run Parameter in silent mode.</param>
        public Parameter(String value)
        {
            Value = value;
        }

    }
}
