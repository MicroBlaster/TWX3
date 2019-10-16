using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    public enum ReferenceType { Internal, Operator, Public, System };


    public class Commands : List<Command>
    {
        //public Reference void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Commands()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            Add(new Command("Add", cmd.Add, 2, 2, true));
            Add(new Command("AddMenu", cmd.AddMenu, 7, 7));
            Add(new Command("And", null, 7, 7, true));
            Add(new Command("Branch", null, 7, 7, true));
            Add(new Command("ClientMessage", null, 7, 7));
            Add(new Command("CloseMenu", null, 7, 7));
            Add(new Command("Connect", null, 7, 7));
            Add(new Command("CutText", null, 7, 7, false, true));
            Add(new Command("Delete", null, 7, 7, true));
            Add(new Command("Disconnect", null, 7, 7));

            Add(new Command("Devide", null, 7, 7, true));
            Add(new Command("Echo", cmd.Echo, 1, -1));
            Add(new Command("FileExists", null, 1, -1, true));
            Add(new Command("GetCharCode", null, 1, -1, false,true));
            Add(new Command("GetConsoleInput", null, 1, -1, true));
            Add(new Command("GetCourse", null, 1, -1, true));
            Add(new Command("GetDate", null, 1, -1, true));
            Add(new Command("Distance", null, 1, -1, true));
            Add(new Command("GetInput", null, 1, -1, true));
            Add(new Command("GetLength", null, 1, -1, false, true));

            Add(new Command("GetMenuValue", null, 1, -1));
            Add(new Command("GetOutText", null, 1, -1, true));
            Add(new Command("GetRnd", null, 1, -1, true));
            Add(new Command("GetSector", null, 1, -1, false, true));
            Add(new Command("GetSectorParamater", null, 1, -1, false, false, true));
            Add(new Command("GetText", null, 1, -1, false, true));
            Add(new Command("GetTime", null, 1, -1, true));
            Add(new Command("Gosub", null, 1, -1));
            Add(new Command("Goto", null, 1, -1));
            Add(new Command("GetWord", null, 1, -1, false, true));

            Add(new Command("GetWordPos", null, 1, -1, false, true));
            Add(new Command("Halt", null, 1, -1));

            Add(new Command("setVar", cmd.setVar, 2, 2, true));
        }

        /// <summary>
        /// Executes a Command.
        /// </summary>
        /// <param name="Command"></param>
        public void Invoke(Script script, Parameters parameters)
        {
            Command c = this.Where(n => n.Name.ToLower() == parameters[0].Value.ToLower()).Single();

            ((Command.CommandReference)c.CmdRef)(script, parameters);
        }
    }

    public class Command
    {
        public delegate void CommandReference(Script script, Parameters parameters);

        // Public Read-only Properties
        public string Name { get; private set; }
        public int MinArgs { get; private set; }
        public int MaxArgs { get; private set; }
        public Delegate CmdRef { get; private set; }
        //public PublicReference CmdRef { get; private set; }


        /// <summary>
        /// Creates a new Command.
        /// </summary>
        /// <param name="name">The name of the Command.</param>
        /// <param name="cmdref">Command handler reference for the Command.</param>
        /// <param name="minArgs">Mininum Number of arguments.</param>
        /// <param name="maxArgs">Mininum Number of arguments.</param>
        public Command(String name, CommandReference cmdref, int minArgs = 0, int maxArgs = 0, bool B1 = false, bool B2 = false, bool B3 = false)
        {
            Name = name;
            MinArgs = minArgs;
            MaxArgs = maxArgs;
            CmdRef = cmdref;
        }
    }
}
