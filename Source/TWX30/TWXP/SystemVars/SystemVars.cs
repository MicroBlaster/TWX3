using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    //public enum ReferenceType { Internal, Operator, Public, System };


    public class SystemVars : List<SystemVar>
    {
        //public Reference void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SystemVars()
        {
            CreateSystemVars();
        }

        private void CreateSystemVars()
        {
            Add(new SystemVar("CURRENTLINE", sys.CURRENTLINE));
        }

        /// <summary>
        /// Executes a SystemVar.
        /// </summary>
        /// <param name="SystemVar"></param>
        public string Invoke(Script script, Parameters parameters)
        {
            SystemVar v = this.Where(n => n.Name == parameters[0].Value).Single();

            return ((SystemVar.SystemReference)v.CmdRef)();
        }
    }

    public class SystemVar
    {
        public delegate string SystemReference();

        // The is the way we used to do it, but you never see it done this way in modern code.
        private ReferenceType type;
        public ReferenceType Type
        {
            get
            {
                return type;
            }
        }



        // Public Read-only Properties
        public string Name { get; private set; }
        public int MinArgs { get; private set; }
        public int MaxArgs { get; private set; }
        public Delegate CmdRef { get; private set; }


        /// <summary>
        /// Creates a new SystemVar.
        /// </summary>
        /// <param name="name">The name of the SystemVar.</param>
        /// <param name="cmdref">SystemVar handler reference for the SystemVar.</param>
        public SystemVar(String name, SystemReference cmdref)
        {
            this.type = ReferenceType.System;
            Name = name;
            MinArgs = 0;
            MaxArgs = 0;
            CmdRef = cmdref;
        }
    }
}
