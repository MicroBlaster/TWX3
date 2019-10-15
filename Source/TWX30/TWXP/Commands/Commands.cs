using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    public enum CommandType { Internal, Operator, Public, System };


    public class Commands : List<Command>
    {
        //public delegate void voidDeligate(string[] args);


        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Commands()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            Add(new Command("add", cmd.Add, 2, 2));
            Add(new Command("addMenu", cmd.AddMenu, 7, 7));
            Add(new Command("echo", cmd.Echo, 1, -1));
            Add(new Command("setVar", cmd.setVar, 2, 2));



            Add(new Command("CURRENTLINE", sys.CURRENTLINE));

        }

        /// <summary>
        /// Executes a command.
        /// </summary>
        /// <param name="command"></param>
        public string Exec(string[] args)
        {
            Command c = this.Where(n => n.Name == args[0]).Single();
            switch(c.Type)
            {
                case CommandType.System:
                    return ((Command.SystemDelegate)c.CmdRef)();
                    
                default:
                    ((Command.PublicDelegate)c.CmdRef)(args);
                    return null;
            }
        }
    }

    public class Command
    {
        public delegate void PublicDelegate(string[] args);
        public delegate string SystemDelegate();


        // The is the way we used to do it, but you never see it done this way in modern code.
        private CommandType type;
        public CommandType Type
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
        //public PublicDelegate CmdRef { get; private set; }


        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="cmdref">Command handler reference for the command.</param>
        /// <param name="minArgs">Mininum Number of arguments.</param>
        /// <param name="maxArgs">Mininum Number of arguments.</param>
        public Command(String name, PublicDelegate cmdref, int minArgs = 0, int maxArgs = 0, CommandType type = CommandType.Public)
        {
            this.type = type;
            Name = name;
            MinArgs = minArgs;
            MaxArgs = maxArgs;
            CmdRef = cmdref;
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="cmdref">Command handler reference for the command.</param>
        public Command(String name, SystemDelegate cmdref)
        {
            this.type = CommandType.System;
            Name = name;
            MinArgs = 0;
            MaxArgs = 0;
            CmdRef = cmdref;
        }
    }
}
