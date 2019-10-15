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
        public static void Add(string[] args)
        {
            double var, value;

            double.TryParse(args[0], out var);
            double.TryParse(args[1], out value);

            args[0] = ((double)(var + value)).ToString();
            // TODO: add percision to calculation.
        }
    }
}
