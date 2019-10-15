using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    public enum ReferenceType { Internal, Operator, Public, System };


    public class CommandReferences : List<CommandReference>
    {
        //public Reference void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public CommandReferences()
        {
            CreateCommandReferences();
        }

        private void CreateCommandReferences()
        {
            Add(new CommandReference("add", cmd.Add, 2, 2));
            Add(new CommandReference("addMenu", cmd.AddMenu, 7, 7));
            Add(new CommandReference("echo", cmd.Echo, 1, -1));
            Add(new CommandReference("setVar", cmd.setVar, 2, 2));



            Add(new CommandReference("CURRENTLINE", sys.CURRENTLINE));

        }

        /// <summary>
        /// Executes a CommandReference.
        /// </summary>
        /// <param name="CommandReference"></param>
        public string Invoke(Script script, Parameters parameters)
        {
            CommandReference c = this.Where(n => n.Name == parameters[0].Value).Single();
            switch(c.Type)
            {
                case ReferenceType.System:
                    return ((CommandReference.SystemReference)c.CmdRef)();
                    
                default:
                    ((CommandReference.PublicReference)c.CmdRef)(script, parameters);
                    return null;
            }
        }
    }

    public class CommandReference
    {
        public delegate void PublicReference(Script script, Parameters parameters);
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
        //public PublicReference CmdRef { get; private set; }


        /// <summary>
        /// Creates a new CommandReference.
        /// </summary>
        /// <param name="name">The name of the CommandReference.</param>
        /// <param name="cmdref">CommandReference handler reference for the CommandReference.</param>
        /// <param name="minArgs">Mininum Number of arguments.</param>
        /// <param name="maxArgs">Mininum Number of arguments.</param>
        public CommandReference(String name, PublicReference cmdref, int minArgs = 0, int maxArgs = 0, ReferenceType type = ReferenceType.Public)
        {
            this.type = type;
            Name = name;
            MinArgs = minArgs;
            MaxArgs = maxArgs;
            CmdRef = cmdref;
        }

        /// <summary>
        /// Creates a new CommandReference.
        /// </summary>
        /// <param name="name">The name of the CommandReference.</param>
        /// <param name="cmdref">CommandReference handler reference for the CommandReference.</param>
        public CommandReference(String name, SystemReference cmdref)
        {
            this.type = ReferenceType.System;
            Name = name;
            MinArgs = 0;
            MaxArgs = 0;
            CmdRef = cmdref;
        }
    }
}
