using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum CommandType { Internal, Operator, Public, System };


    public partial class Labels : List<Label>
    {
        //public delegate void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Labels()
        {

        }
    }

    public class Label
    {
        // Public Read-only Properties
        public string Name { get; private set; }
        public string Value { get; private set; }
        public string DecValue { get; private set; }
        public bool IsNumeric { get; private set; }

        /// <summary>
        /// Creates a new Label.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="silent">Run Label in silent mode.</param>
        public Label(String name)
        {
            Name = name;
        }
    }
}
