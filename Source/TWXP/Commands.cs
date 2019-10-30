using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TWXP
{
    public static class cmd
    {
        public static List<Command> cmdList {get; private set;}

        public static void Load()
        {
            if (cmdList != null) return;
            cmdList = new List<Command>();

            cmdList.Add(new Command("Add",true));
            cmdList.Add(new Command("AddMenu"));
            cmdList.Add(new Command("And",true));
            cmdList.Add(new Command("Branch",true));
            cmdList.Add(new Command("ClientMessage"));
            cmdList.Add(new Command("CloseMenu"));
            cmdList.Add(new Command("Connect"));
            cmdList.Add(new Command("CutText"));
            cmdList.Add(new Command("Delete"));
            cmdList.Add(new Command("Disconnect"));
            cmdList.Add(new Command("Divide"));
            cmdList.Add(new Command("Echo"));
            cmdList.Add(new Command("FileExists"));
            cmdList.Add(new Command("GetCharCode"));
            cmdList.Add(new Command("GetConsoleInput"));
            cmdList.Add(new Command("GetCourse"));
            cmdList.Add(new Command("GetDate"));
            cmdList.Add(new Command("GetDistance"));
            cmdList.Add(new Command("GetInput"));
            cmdList.Add(new Command("GetLength"));
            cmdList.Add(new Command("GetMenuValue"));
            cmdList.Add(new Command("GetGetOutText"));
            cmdList.Add(new Command("GetRnd"));
            cmdList.Add(new Command("GetSector"));
            cmdList.Add(new Command("GetSectorParameter"));
            cmdList.Add(new Command("GetText"));
            cmdList.Add(new Command("GetTime"));
            cmdList.Add(new Command("Gosub"));
            cmdList.Add(new Command("Goto"));
            cmdList.Add(new Command("GetWord"));
            cmdList.Add(new Command("GetWordPos"));
            cmdList.Add(new Command("Halt"));
            cmdList.Add(new Command("IsEquil", true));
            cmdList.Add(new Command("IsGreater", true));
            cmdList.Add(new Command("IsGreaterEquil", true));
            cmdList.Add(new Command("IsLesser", true));
            cmdList.Add(new Command("IsLesserEquil", true));
            cmdList.Add(new Command("IsNotEquil", true));
            cmdList.Add(new Command("IsNumber"));
            cmdList.Add(new Command("KillWindow"));
            cmdList.Add(new Command("KillAllTriggers"));
            cmdList.Add(new Command("KillTriggers"));
            cmdList.Add(new Command("Load"));
            cmdList.Add(new Command("LoadVar"));
            cmdList.Add(new Command("Logging"));
            cmdList.Add(new Command("LowerCase"));
            cmdList.Add(new Command("MergeText"));
            cmdList.Add(new Command("Multiply"));
            cmdList.Add(new Command("OpenMenu"));
            cmdList.Add(new Command("Or",true));
            cmdList.Add(new Command("Pause"));
            cmdList.Add(new Command("ProcessIn"));
            cmdList.Add(new Command("ProcessOut"));
            cmdList.Add(new Command("Read"));
            cmdList.Add(new Command("Rename"));
            cmdList.Add(new Command("ReplaceText"));
            cmdList.Add(new Command("ReqRecording"));
            cmdList.Add(new Command("Return"));
            cmdList.Add(new Command("Round"));
            cmdList.Add(new Command("SaveVar"));
            cmdList.Add(new Command("Send"));
            cmdList.Add(new Command("SetArray"));
            cmdList.Add(new Command("SetDelayTrigger"));
            cmdList.Add(new Command("SetEventTrigger"));
            cmdList.Add(new Command("SetMenuHelp"));
            cmdList.Add(new Command("SetMenuValue"));
            cmdList.Add(new Command("SetMenuOptions"));
            cmdList.Add(new Command("SetPrecision"));
            cmdList.Add(new Command("SetProgVar"));
            cmdList.Add(new Command("SetSectorParameter"));
            cmdList.Add(new Command("SetTextLineTrigger"));
            cmdList.Add(new Command("SetTextOutTrigger"));
            cmdList.Add(new Command("SetTextTrigger"));
            cmdList.Add(new Command("SetVar"));
            cmdList.Add(new Command("SetWindowContents"));
            cmdList.Add(new Command("Sound"));
            cmdList.Add(new Command("Stop"));
            cmdList.Add(new Command("StripText"));
            cmdList.Add(new Command("Subtract",true));
            cmdList.Add(new Command("SYS_CHECK", true));
            cmdList.Add(new Command("SYS_FAIL", true));
            cmdList.Add(new Command("SYS_KILL", true));
            cmdList.Add(new Command("SYS_NOAUTH", true));
            cmdList.Add(new Command("SYS_NOP", true));
            cmdList.Add(new Command("SYS_SHOWMSG", true));
            cmdList.Add(new Command("SystemScript"));
            cmdList.Add(new Command("UpoperCase"));
            cmdList.Add(new Command("Xor",true));
            cmdList.Add(new Command("Window"));
            cmdList.Add(new Command("Write"));

            // Commands added for 2.04beta
            cmdList.Add(new Command("GetTimer"));
            cmdList.Add(new Command("ReadToArray"));

            // Commands added for 2.04final
            cmdList.Add(new Command("ClearAllAvoids"));
            cmdList.Add(new Command("ClearAvoid"));
            cmdList.Add(new Command("GetAllCoarses"));
            cmdList.Add(new Command("GetFileList"));
            cmdList.Add(new Command("GetNearestWarps"));
            cmdList.Add(new Command("GetScriptVersion"));
            cmdList.Add(new Command("ListActiveScripts"));
            cmdList.Add(new Command("ListAvoids"));
            cmdList.Add(new Command("ListSectorParameters"));
            cmdList.Add(new Command("SetAvoid"));

            // Commands added for 2.05beta
            cmdList.Add(new Command("CutLengths"));
            cmdList.Add(new Command("Format"));
            cmdList.Add(new Command("GetDirList"));
            cmdList.Add(new Command("GetWordCount"));
            cmdList.Add(new Command("MakeDir"));
            cmdList.Add(new Command("PadLeft"));
            cmdList.Add(new Command("PadRight"));
            cmdList.Add(new Command("RemoveDir"));
            cmdList.Add(new Command("SetMenuKey"));
            cmdList.Add(new Command("SplitText"));
            cmdList.Add(new Command("Trim"));
            cmdList.Add(new Command("Truncate"));
        }

        public static void Add(Param a, double b)
        {
            a.Update((double)a + b);
        }

        public static void And(Param a, bool b)
        {
            a.Update((bool)a && b);
        }

        public static void SetVar(Param a, double b)
        {
            a.Update(b);
        }

        public static void Echo(params Param[] param)
        {
            string output = "";
            foreach(Param p in param)
            {
                output += p;
            }
            Debug.Write ($"Echo: {output}\n");
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
