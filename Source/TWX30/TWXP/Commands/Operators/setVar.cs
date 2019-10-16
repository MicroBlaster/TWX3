using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWXP
{
    static partial class cmd
    {
        //public static void Echo(object sender, EventArgs e)

        /// <summary>
        /// Add a value to a variable.
        /// </summary>
        /// <param var>Variable to be modified.</param>
        /// <param value>Value to be set to var.</param>        
        public static void setVar(Script script, Parameters parameters)
        {
            parameters[0] = parameters[1];

        }
    }
}
