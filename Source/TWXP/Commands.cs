using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TWXP
{
    public static class cmd
    {
        public static List<Command> Commands {get; private set;}
        private static Proxy proxy;

        public static void Load(Proxy p)
        {
            proxy = p;

            if (Commands != null) return;
            Commands = new List<Command>();

            Commands.Add(new Command("Add",true));
            Commands.Add(new Command("AddMenu"));  //TODO:
            Commands.Add(new Command("And",true));
            Commands.Add(new Command("Branch",true));
            Commands.Add(new Command("ClientMessage"));  //TODO:
            Commands.Add(new Command("CloseMenu"));  //TODO:
            Commands.Add(new Command("Connect")); //In-Progress
            Commands.Add(new Command("CutText")); //TODO:
            Commands.Add(new Command("Delete")); //TODO:
            Commands.Add(new Command("Disconnect")); //In-Progress
            Commands.Add(new Command("Divide",true));
            Commands.Add(new Command("Echo")); //In-Progress
            Commands.Add(new Command("FileExists")); //TODO: --- through rest of list, except operators ---
            Commands.Add(new Command("GetCharCode"));
            Commands.Add(new Command("GetConsoleInput"));
            Commands.Add(new Command("GetCourse"));
            Commands.Add(new Command("GetDate"));
            Commands.Add(new Command("GetDistance"));
            Commands.Add(new Command("GetInput"));
            Commands.Add(new Command("GetLength"));
            Commands.Add(new Command("GetMenuValue"));
            Commands.Add(new Command("GetGetOutText"));
            Commands.Add(new Command("GetRnd"));
            Commands.Add(new Command("GetSector"));
            Commands.Add(new Command("GetSectorParameter"));
            Commands.Add(new Command("GetText"));
            Commands.Add(new Command("GetTime"));
            Commands.Add(new Command("Gosub"));
            Commands.Add(new Command("Goto"));
            Commands.Add(new Command("GetWord"));
            Commands.Add(new Command("GetWordPos"));
            Commands.Add(new Command("Halt"));
            Commands.Add(new Command("IsEquil", true));
            Commands.Add(new Command("IsGreater", true));
            Commands.Add(new Command("IsGreaterEquil", true));
            Commands.Add(new Command("IsLesser", true));
            Commands.Add(new Command("IsLesserEquil", true));
            Commands.Add(new Command("IsNotEquil", true));
            Commands.Add(new Command("IsNumber"));
            Commands.Add(new Command("KillWindow"));
            Commands.Add(new Command("KillAllTriggers"));
            Commands.Add(new Command("KillTriggers"));
            Commands.Add(new Command("Load"));
            Commands.Add(new Command("LoadVar"));
            Commands.Add(new Command("Logging"));
            Commands.Add(new Command("LowerCase"));
            Commands.Add(new Command("MergeText"));
            Commands.Add(new Command("Multiply",true));
            Commands.Add(new Command("OpenMenu"));
            Commands.Add(new Command("Or",true));
            Commands.Add(new Command("Pause"));
            Commands.Add(new Command("ProcessIn"));
            Commands.Add(new Command("ProcessOut"));
            Commands.Add(new Command("Read"));
            Commands.Add(new Command("Rename"));
            Commands.Add(new Command("ReplaceText"));
            Commands.Add(new Command("ReqRecording"));
            Commands.Add(new Command("Return"));
            Commands.Add(new Command("Round"));
            Commands.Add(new Command("SaveVar"));
            Commands.Add(new Command("Send"));
            Commands.Add(new Command("SetArray"));
            Commands.Add(new Command("SetDelayTrigger"));
            Commands.Add(new Command("SetEventTrigger"));
            Commands.Add(new Command("SetMenuHelp"));
            Commands.Add(new Command("SetMenuValue"));
            Commands.Add(new Command("SetMenuOptions"));
            Commands.Add(new Command("SetPrecision"));
            Commands.Add(new Command("SetProgVar"));
            Commands.Add(new Command("SetSectorParameter"));
            Commands.Add(new Command("SetTextLineTrigger"));
            Commands.Add(new Command("SetTextOutTrigger"));
            Commands.Add(new Command("SetTextTrigger"));
            Commands.Add(new Command("SetVar",true));
            Commands.Add(new Command("SetWindowContents"));
            Commands.Add(new Command("Sound"));
            Commands.Add(new Command("Stop"));
            Commands.Add(new Command("StripText"));
            Commands.Add(new Command("Subtract",true));
            Commands.Add(new Command("SYS_CHECK", true));
            Commands.Add(new Command("SYS_FAIL", true));
            Commands.Add(new Command("SYS_KILL", true));
            Commands.Add(new Command("SYS_NOAUTH", true));
            Commands.Add(new Command("SYS_NOP", true));
            Commands.Add(new Command("SYS_SHOWMSG", true));
            Commands.Add(new Command("SystemScript"));
            Commands.Add(new Command("UpoperCase"));
            Commands.Add(new Command("Xor",true));
            Commands.Add(new Command("Window"));
            Commands.Add(new Command("Write"));

            // Commands added for 2.04beta
            Commands.Add(new Command("GetTimer"));
            Commands.Add(new Command("ReadToArray"));

            // Commands added for 2.04final
            Commands.Add(new Command("ClearAllAvoids"));
            Commands.Add(new Command("ClearAvoid"));
            Commands.Add(new Command("GetAllCoarses"));
            Commands.Add(new Command("GetFileList"));
            Commands.Add(new Command("GetNearestWarps"));
            Commands.Add(new Command("GetScriptVersion"));
            Commands.Add(new Command("ListActiveScripts"));
            Commands.Add(new Command("ListAvoids"));
            Commands.Add(new Command("ListSectorParameters"));
            Commands.Add(new Command("SetAvoid"));

            // Commands added for 2.05beta
            Commands.Add(new Command("CutLengths"));
            Commands.Add(new Command("Format"));
            Commands.Add(new Command("GetDirList"));
            Commands.Add(new Command("GetWordCount"));
            Commands.Add(new Command("MakeDir"));
            Commands.Add(new Command("PadLeft"));
            Commands.Add(new Command("PadRight"));
            Commands.Add(new Command("RemoveDir"));
            Commands.Add(new Command("SetMenuKey"));
            Commands.Add(new Command("SplitText"));
            Commands.Add(new Command("Trim"));
            Commands.Add(new Command("Truncate"));
        }

        /// <summary>
        /// Mathmatical operator cmd.Multiply - Performs mathematical multiplication on a variable.
        /// </summary>
        /// <param name="a">The variable to be multiplied.</param>
        /// <param name="b">The amount to multiply the variable by.</param>
        public static void Multiply(Param a, double b)
        {
            a.Update((double)a * b);
        }

        /// <summary>
        /// Mathmatical Operator cmd.Multiply - Performs mathematical division  on a variable.
        /// </summary>
        /// <param name="a">The variable to be divided.</param>
        /// <param name="b">The amount to divide the variable by.</param>
        public static void Divide(Param a, double b)
        {
            a.Update((double)a / b);
        }

        /// <summary>
        /// Mathmatical Operator cmd.Add - Adds a value to a variable.
        /// </summary>
        /// <param name="a">The variable that will have its value added to.</param>
        /// <param name="b">The amount the variable will be increased by.</param>
        public static void Add(Param a, double b)
        {
            a.Update((double)a + b);
        }

        /// <summary>
        /// Mathmatical Operator cmd.Subtract - Subtracts a value from a variable.
        /// </summary>
        /// <param name="a">The variable that will be subtracted from.</param>
        /// <param name="b">The amount the variable will be subtracted by</param>
        public static void Subtract(Param a, double b)
        {
            a.Update((double)a - b);
        }

        /// <summary>
        /// Logincal Operator cmd.And - Performs a logical 'AND' on a variable.
        /// </summary>
        /// <param name="a">The variable to be operated on. The value in this variable must be either TRUE (1) or FALSE (0).</param>
        /// <param name="b">The value to be operated by. This value must be either TRUE (1) or FALSE (0).</param>
        public static void And(Param a, bool b)
        {
            a.Update((bool)a && b);
        }

        /// <summary>
        /// Logincal Operator cmd.Or - Performs a logical 'OR' on a variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Or(Param a, bool b)
        {
            a.Update((bool)a || b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Xor(Param a, bool b)
        {
            a.Update((bool)a ^ b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public static void Not(Param a)
        {
            a.Update(!(bool)a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static void IsEquil(Param a, double b, double c)
        {
            a.Update(b == c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static void IsNotEquil(Param a, double b, double c)
        {
            a.Update(b != c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static void IsGreater(Param a, double b, double c)
        {
            a.Update(b > c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static void IsGeaterEquil(Param a, double b, double c)
        {
            a.Update(b >= c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static void IsLesser(Param a, double b, double c)
        {
            a.Update(b < c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static void IsLesserEquil(Param a, double b, double c)
        {
            a.Update(b <= c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void SetVar(Param a, double b)
        {
            a.Update(b);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public static void Echo(params Param[] param)
        {
            StringBuilder output = new StringBuilder();
            //string output = "";
            foreach (Param p in param)
            {
                output.Append((string)p);
            }

            proxy.Echo(output.ToString());
            Debug.Write($"Echo: {output}\n");
        }

    }

    public class Command
    {
        public string Name {get; private set;}
        public bool Depreciated { get; private set; }

        public Command (string name, bool depreciated = false)
        {
            Name = name;
            Depreciated = depreciated;
        }
    }
}
