using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum CommandType { Internal, Operator, Public, System };


    public partial class Params : List<Param>
    {
        //public delegate void voidDeligate(string[] args);

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Params()
        {

        }


    }

    public class Param
    {
        // Public Read-only Properties
        //public string Name { get; private set; }
        public string VarName { get; private set; }
        public string Value { get; private set; }
        public double DecValue { get; private set; }
        public bool IsNumeric { get; private set; }
        public bool IsVarable { get; private set; }

        private Script script;

        /// <summary>
        /// Creates a new Param.
        /// </summary>
        /// <param name="value">The iniial value to be asigned to the paramater.</param>
        public Param(Script script, string value, bool isVarable = false)
        {
            // Store the script in a private for use by Vars
            this.script = script;

            // Set the IsVarable flag.
            IsVarable = isVarable;

            // Update the initial value.
            Update(value, true);
        }

        public void Update(string value, bool skipvar = false)
        {
            // Save the value string as a property.
            Value = value;
            IsNumeric = false;

            // Try to parse the input string as a number.
            double decValue = 0;
            if (Double.TryParse(value, out decValue))
            {
                IsNumeric = true;
                DecValue = decValue;
            }

            if (!skipvar) UpdateVar();
        }

        public void Update(double value, bool skipvar = false)
        {
            // Save the value to the properties.
            IsNumeric = true;
            Value = value.ToString();
            DecValue = value;

            if (!skipvar) UpdateVar();
        }

        private void UpdateVar()
        {
            if (IsVarable)
            {
                try
                {
                    Varable var = script.Vars.Where(v => v.Name.ToLower() == VarName.ToLower()).Single();

                    if (IsNumeric)
                        var.Update(DecValue);
                    else
                        var.Update(Value);
                }
                catch { }
            }
        }

        public void LoadVar()
        {
            IsVarable = true;

            try
            {
                Varable var = script.Vars.Where(v => v.Name.ToLower() == Value.ToLower()).Single();

                if (String.IsNullOrEmpty(VarName)) VarName = Value;

                if (var.IsNumeric)
                    Update(var.DecValue, true);
                else
                    Update(var.Value, true);

            }
            catch 
            {
                if (String.IsNullOrEmpty(VarName)) VarName = Value;
                script.Vars.Add(new Varable(VarName));
            }
        }

        public void LoadValue()
        {
            try
            {
                Varable var = script.Vars.Where(v => v.Name.ToLower() == Value.ToLower()).Single();

                if (var.IsNumeric)
                    Update(var.DecValue, true);
                else
                    Update(var.Value, true);
            }
            catch { }
        }
    }
}
