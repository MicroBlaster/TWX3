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
        /// <param value>Value to add to var.</param>        
        public static void Add(Script script, Parameters parameters)
        {
            double var, value;

            //double.TryParse(parameters[0], out var);
            //double.TryParse(parameters[1], out value);

            //parameters[0] = ((double)(var + value)).ToString();
            // TODO: add percision to calculation.
        }
    }
}
