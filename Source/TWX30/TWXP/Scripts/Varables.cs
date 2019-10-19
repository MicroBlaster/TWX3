using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum CommandType { Internal, Operator, Public, System };


    public partial class Varables : List<Varable>
    {
        //public delegate void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Varables()
        {

        }
    }

    public class Varable
    {
        // Public Read-only Properties
        public string Name { get; private set; }
        public string Value { get; private set; }
        public double DecValue { get; private set; }
        public bool IsNumeric { get; private set; }

        /// <summary>
        /// Creates a new Varable.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="silent">Run Varable in silent mode.</param>
        public Varable(string name)
        {
            Name = name;
        }

        public void Update(string value)
        {
            Value = value;
            DecValue = 0;
            IsNumeric = false;
        }

        public void Update(Double decValue)
        {
            Value = decValue.ToString();
            DecValue = decValue;
            IsNumeric = true;
        }
    }
}
