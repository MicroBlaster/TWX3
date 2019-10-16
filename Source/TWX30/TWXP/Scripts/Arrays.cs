using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum CommandType { Internal, Operator, Public, System };


    public partial class Arrays : List<Array>
    {
        List<int> Dims = new List<int>();

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Arrays()
        {

        }
    }

    public class Array
    {
        List<Array> Vars;

        // Public Read-only Properties
        public string Name { get; private set; }

        /// <summary>
        /// Creates a new Array.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="silent">Run Array in silent mode.</param>
        public Array(String name)
        {
            Vars = new List<Array>();

            Name = name;
        }
    }
}
