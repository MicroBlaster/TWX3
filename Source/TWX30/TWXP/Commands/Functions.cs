using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWXP
{
    static class Function
    {
        //public static void Echo(object sender, EventArgs e)

        /// <summary>
        /// Add a menu.
        /// </summary>
        /// <param var>Variable to be modified.</param>
        /// <param value>Value to be set to var.</param>        
        public static void AddMenu(Script script, Params param)
        {

        }

        /// <summary>
        /// Echo Args[] to all connected clients.
        /// </summary>
        /// <param args[]>Values to be echoed.</param>
        public static void Echo(Script script, Params param)
        {
            string s = "";
            foreach (Param p in param)
            {
                s += p.Value;
            }
            script.Echo(s);
        }

    }
}
