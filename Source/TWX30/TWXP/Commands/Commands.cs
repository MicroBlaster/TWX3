using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TWXP
{
    public enum ReferenceType { Internal, Operator, Public, System };


    public static class Commands
    {
        //public Reference void voidDeligate(string[] args);
        static List<Command> cmds = new List<Command>();

        /// <summary>
        /// Default Constructor.
        /// </summary>
        //public Commands()
        //{
        //    CreateCommands();
        //}

        public static void CreateCommands()
        {
            cmds.Add(new Command("Add", Operators.Add, 2, 2, true));
            cmds.Add(new Command("AddMenu", Function.AddMenu, 7, 7));
            cmds.Add(new Command("And", null, 7, 7, true));
            cmds.Add(new Command("Branch", null, 7, 7, true));
            cmds.Add(new Command("ClientMessage", null, 7, 7));
            cmds.Add(new Command("CloseMenu", null, 7, 7));
            cmds.Add(new Command("Connect", null, 7, 7));
            cmds.Add(new Command("CutText", null, 7, 7, false, true));
            cmds.Add(new Command("Delete", null, 7, 7, true));
            cmds.Add(new Command("Disconnect", null, 7, 7));

            cmds.Add(new Command("Divide", null, 7, 7, true));
            cmds.Add(new Command("Echo", Function.Echo, 1, -1));
            cmds.Add(new Command("FileExists", null, 1, -1, true));
            cmds.Add(new Command("GetCharCode", null, 1, -1, false,true));
            cmds.Add(new Command("GetConsoleInput", null, 1, -1, true));
            cmds.Add(new Command("GetCourse", null, 1, -1, true));
            cmds.Add(new Command("GetDate", null, 1, -1, true));
            cmds.Add(new Command("Distance", null, 1, -1, true));
            cmds.Add(new Command("GetInput", null, 1, -1, true));
            cmds.Add(new Command("GetLength", null, 1, -1, false, true));

            cmds.Add(new Command("GetMenuValue", null, 1, -1));
            cmds.Add(new Command("GetOutText", null, 1, -1, true));
            cmds.Add(new Command("GetRnd", null, 1, -1, true));
            cmds.Add(new Command("GetSector", null, 1, -1, false, true));
            cmds.Add(new Command("GetSectorParamater", null, 1, -1, false, false, true));
            cmds.Add(new Command("GetText", null, 1, -1, false, true));
            cmds.Add(new Command("GetTime", null, 1, -1, true));
            cmds.Add(new Command("Gosub", null, 1, -1));
            cmds.Add(new Command("Goto", null, 1, -1));
            cmds.Add(new Command("GetWord", null, 1, -1, false, true));

            cmds.Add(new Command("GetWordPos", null, 1, -1, false, true));
            cmds.Add(new Command("Halt", null, 1, -1));

            cmds.Add(new Command("setVar", Operators.setVar, 2, 2, true));
        }

        /// <summary>
        /// Executes a Command.
        /// </summary>
        /// <param name="Command"></param>
        public static void Invoke(Script script, ScriptCmd sc)
        {
            string cmd = sc.Param[0].Value.ToLower();
            sc.Param.Remove(sc.Param[0]);

            Command command = cmds.Where(c => c.Name.ToLower() == cmd).Single();
            Command.CmdRef cmdref = (Command.CmdRef)command.Reference;

            for (int index = 0; index < sc.Param.Count(); index++)
            {
                if((command.isVar != null) && command.isVar[index])
                {
                    sc.Param[index].LoadVar();
                }
                else
                {
                    sc.Param[index].LoadValue();
                }
            }

            cmdref(script, sc.Param);
        }
    }

    public class Command
    {
        public delegate void CmdRef(Script script, Params parameters);

        // Public Read-only Properties
        public string Name { get; private set; }
        public int MinArgs { get; private set; }
        public int MaxArgs { get; private set; }
        public Delegate Reference { get; private set; }
        //public PublicReference CmdRef { get; private set; }

        public bool[] isVar { get; private set; }

        /// <summary>
        /// Creates a new Command.
        /// </summary>
        /// <param name="name">The name of the Command.</param>
        /// <param name="cmdref">Command handler reference for the Command.</param>
        /// <param name="minArgs">Mininum Number of arguments.</param>
        /// <param name="maxArgs">Mininum Number of arguments.</param>
        public Command(String name, CmdRef reference, int minArgs = 0, int maxArgs = 0, bool B0 = false, bool B1 = false, bool B2 = false)
        {
            // Save initial values as Properties.
            Name = name;
            MinArgs = minArgs;
            MaxArgs = maxArgs;
            Reference = reference;

            // Test to see if there are any Vars and create the isVar array.
            // else set isVar = null.
            if (maxArgs > 0 && (B0 || B1 || B2))
            {
                // Create the isVar array.
                isVar = new bool[maxArgs];

                for(int index = 0; index < maxArgs; index++)
                {
                    // Set isVar[index] to false unless it is flagged as a Var.
                    switch (index)
                    {
                        case 0 : isVar[index] = B0; break;
                        case 1 : isVar[index] = B1; break;
                        case 2 : isVar[index] = B2; break;
                        default: isVar[index] = false; break;
                    }
                }
            }
            else
            {
                // This command has no Vars. Set isVar = null.
                isVar = null;
            }
        }
    }
}
