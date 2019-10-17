using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWXP
{
    static partial class Operators
    {
        //public static void Echo(object sender, EventArgs e)

        /// <summary>
        /// Add a value to a variable.
        /// </summary>
        /// <param var>Variable to be modified.</param>
        /// <param value>Value to add to var.</param>        
        public static void Add(Script script, Params param)
        {
            param[0].Update(param[0].DecValue + param[1].DecValue);
        }

        /// <summary>
        /// Add a value to a variable.
        /// </summary>
        /// <param var>Variable to be modified.</param>
        /// <param value>Value to be set to var.</param>        
        public static void setVar(Script script, Params param)
        {
            param[0].Update(param[1].Value);
        }


    }
}
