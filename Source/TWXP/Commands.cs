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
#region Command List
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
#endregion
#region Mathmatical operator commands    
        
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
#endregion
#region Logincal operator commands    

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
        /// <param name="a">The variable to be operated. The value in this variable must be either TRUE (1) or FALSE (0).</param>
        /// <param name="b">The value to be operated by. This value must be either TRUE (1) or FALSE (0).</param>
        public static void Or(Param a, bool b)
        {
            a.Update((bool)a || b);
        }

        /// <summary>
        /// Logincal Operator cmd.Xor - Performs a logical 'XOR' on a variable.
        /// </summary>
        /// <param name="a">The variable to be operated. The value in this variable must be either TRUE (1) or FALSE (0).</param>
        /// <param name="b">The value to be operated by. This value must be either TRUE (1) or FALSE (0).</param>
        public static void Xor(Param a, bool b)
        {
            a.Update((bool)a ^ b);
        }

        /// <summary>
        /// Logincal Operator cmd.Not - Performs a logical 'Not' on a variable.
        /// </summary>
        /// <param name="a">The variable to be operated. The boolean oposite of this varable will be returned</param>
        public static void Not(Param a)
        {
            a.Update(!(bool)a);
        }
#endregion
#region Relational operator commands    

        /// <summary>
        /// Relational Operators cmd.IsEquil - True if they are equal.
        /// </summary>
        /// <param name="a">A variable to hold the result of the comparison.</param>
        /// <param name="b">"Left" hand operator to be compared.</param>
        /// <param name="c">"Right" hand operator to be compared.</param>
        public static void IsEquil(Param a, double b, double c)
        {
            a.Update(b == c);
        }

        /// <summary>
        /// Relational Operators cmd.IsNotEquil - True if they are not equal.
        /// </summary>
        /// <param name="a">A variable to hold the result of the comparison.</param>
        /// <param name="b">"Left" hand operator to be compared.</param>
        /// <param name="c">"Right" hand operator to be compared.</param>
        public static void IsNotEquil(Param a, double b, double c)
        {
            a.Update(b != c);
        }

        /// <summary>
        /// Relational Operators cmd.IsGreater - True if the first is greator than the second.
        /// </summary>
        /// <param name="a">A variable to hold the result of the comparison.</param>
        /// <param name="b">"Left" hand operator to be compared.</param>
        /// <param name="c">"Right" hand operator to be compared.</param>
        public static void IsGreater(Param a, double b, double c)
        {
            a.Update(b > c);
        }

        /// <summary>
        /// Relational Operators cmd.IsGeaterEquil - True if the first is greater than or equal to the second.
        /// </summary>
        /// <param name="a">A variable to hold the result of the comparison.</param>
        /// <param name="b">"Left" hand operator to be compared.</param>
        /// <param name="c">"Right" hand operator to be compared.</param>
        public static void IsGeaterEquil(Param a, double b, double c)
        {
            a.Update(b >= c);
        }

        /// <summary>
        /// Relational Operators cmd.IsLesser - True if the first is less than the second.
        /// </summary>
        /// <param name="a">A variable to hold the result of the comparison.</param>
        /// <param name="b">"Left" hand operator to be compared.</param>
        /// <param name="c">"Right" hand operator to be compared.</param>
        public static void IsLesser(Param a, double b, double c)
        {
            a.Update(b < c);
        }

        /// <summary>
        /// Relational Operators cmd.IsLesserEquil - True if the first is less than or equal to the second.
        /// </summary>
        /// <param name="a">A variable to hold the result of the comparison.</param>
        /// <param name="b">"Left" hand operator to be compared.</param>
        /// <param name="c">"Right" hand operator to be compared.</param>
        public static void IsLesserEquil(Param a, double b, double c)
        {
            a.Update(b <= c);
        }
#endregion
#region Assignment operator command    

        /// <summary>
        /// Assignment Operator - Asigns a value to a parameter.
        /// </summary>
        /// <param name="a">The paramater to be asigned to.</param>
        /// <param name="b">The value to be asigned to the paramater.</param>
        public static void SetVar(Param a, double b)
        {
            a.Update(b);
        }

#endregion
#region Terminal commands

        /// <summary>
        /// Command cmd.Connect - Connects TWX Proxy to a remote server.
        /// </summary>
        public static void Connect()
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.Disconnect - Disconnects TWX Proxy from the remote server.
        /// </summary>
        public static void Disconnect()
        {
            //TODO:
        }

    
        /// <summary>
        /// Command cmd.ClientMessage - Broadcasts a formatted string, to all connected client
        /// sessions. String is sent in Bright White and the prompt is re-displayed afterwards.
        /// </summary>
        /// <param name="String">String to be broadcast.</param>
        public static void ClientMessage(string s)
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Echo - Echos all parameters, as strings, to all connected client sessions.
        /// </summary>
        /// <param name="param">Parameters to be concatenated and echoed</param>
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

        
        /// <summary>
        /// Command cmd.Send - Sends text to the remote server.
        /// </summary>
        /// <param name="param">Parameters to be concatenated and sent.</param>
        public static void Send(params Param[] param)
        {
            //TODO:
        }

        
        /// <summary>
        /// Command cmd.GetInput - Gets a line of text from the user.
        /// </summary>
        /// <param name="var">The paramater to hold the line of text entered by the user.</param>
        /// <param name="prompt">The text to display above the input prompt.</param>
        public static void GetInput(Param var, string prompt)
        {
            var.Update(GetInput(prompt));
        }

        public static string GetInput(string prompt)
        {
            //TODO:
            return "";
        }

        
        /// <summary>
        /// Command cmd.GetConsoleInput - Get input from a connected terminal without sending it.
        /// </summary>
        /// <param name="var">The paramater to hold the line of text entered by the user.</param>
        /// <param name="prompt">The text to display above the input prompt.</param>
        /// <param name="singleKey">.</param>
        /// For backwards compatability, any value for the singleKey parameter will be interperted as true.
        public static void GetConsoleInput(Param var, string prompt, bool singleKey = false)
        {
            var.Update(GetConsoleInput(prompt, singleKey));
        }

        public static string GetConsoleInput(string prompt, bool singleKey = false)
        {
            //TODO:
            return "";
        }

        /// <summary>
        /// Command cmd.GetOuttext - Retrieve any outgoing text from TWX Proxy's outgoing buffer.
        /// </summary>
        /// <param name="var">The paramater to hold the outgoing text.</param>
        public static void GetOuttext(Param var)
        {
            var.Update(GetOuttext());
        }

        public static string GetOuttext()
        {
            //TODO:
            return "";
        }

        
        /// <summary>
        /// Command cmd.ProcessIn  - Emulates incoming text from the remote server, activating TextLine triggers.
        /// </summary>
        /// <param name="AllScripts">True will activate all matching triggers in ALL scripts, while false will onlly process triggers from the current script.</param>
        /// <param name="text">The text to be processed as inbound.</param>
        public static void ProcessIn(bool AllScripts, string text)
        {
            //TODO:
        }

        
        /// <summary>
        /// Command cmd.ProcessOut  - Resumes processing out outgoing data that was trapped by a TextOutTrigger.
        /// </summary>
        /// <param name="text">The text to be processed as outbound.</param>
        public static void ProcessOut()
        {
            //TODO:
        }

        
        
        /// <summary>
        /// Command cmd.GetDeafClients  - Retreives the status of any deaf clients.
        /// </summary>
        /// <param name="var">The paramater that will contain TRUE if any dead clients are found.</param>
        public static void GetDeafClients(Param var)
        {
            var.Update(GetDeafClients());
        }
                       
        public static bool GetDeafClients()
        {
            //TODO:
            return false;
        }

        /// <summary>
        /// Command cmd.SetDeafClients - Sets the deaf status on all clients.
        /// </summary>
        /// <param name="var">An optional variable that will wake clients if set to FALSE. By default the command will deafen all clients.</param>
        public static void SetDeafClients(bool deafen = true)
        {
            //TODO:
        }

        
        
        
#endregion
#region Delay and Trigger commands
     
        /// <summary>
        /// Command cmd.setDelayTrigger - Creates a trigger that will activate after a specified time period.
        /// </summary>
        /// <param name="Name">The name of the trigger to create. This name is used for later references to the trigger.</param>
        /// <param name="Label">A label within the script to jump to when the trigger is activated.</param>
        /// <param name="Ticks">The number of milliseconds to wait before the delay trigger automatically activates itself.</param>
        public static void SetDelayTrigger(string name, string label, int tics)
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.SetEventTrigger - Creates a trigger that will activate on a certain program event.
        /// </summary>
        /// <param name="Name">The name of the trigger to create. This name is used for later references to the trigger.</param>
        /// <param name="Label">A label within the script to jump to when the trigger is activated.</param>
        /// <param name="Event">The name of the program event to attach the trigger to.</param>
        /// <param name="Parameter">(optional) parameter for specific events.</param>
        public static void SetEventTrigger(string name, string label, string fireon, string parameter)
        {
            //TODO:
        }
                       
//SCRIPT LOADED : Activates when a script is loaded. Parameter = Script Name.
//SCRIPT STOPPED : Activates when a script is terminated. Parameter = Script Name.
//CONNECTION ACCEPTED : Server connection accepted. (no parameters).
//CONNECTION LOST : Server connection lost. (no parameters).
//CLIENT CONNECTED : Telnet client connected. (no parameters).
//CLIENT DISCONNECTED : Telnet client disconnected. (no parameters).
//TIME HIT : Activates when specified time is hit. Parameter = specified time.                       
        
        /// <summary>
        /// Command cmd.SetTextLineTrigger - Creates a trigger activated when specific text is received from Server.
        /// </summary>
        /// <param name="Name">The name of the trigger to create. This name is used for later references to the trigger.</param>
        /// <param name="Label">A label within the script to jump to when the trigger is activated.</param>
        /// <param name="Value">A value that is required to be in the block of incoming text for the trigger to activate. If this parameter is not specified, the trigger will activate on any line - even if it is blank.</param>
        public static void SetTextLineTrigger(string name, string label, string Value)
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.SetTextTrigger - Creates a text trigger activated when specific text is received.
        /// </summary>
        /// <param name="Name">The name of the trigger to create. This name is used for later references to the trigger.</param>
        /// <param name="Label">A label within the script to jump to when the trigger is activated.</param>
        /// <param name="Value">A value that is required to be in the block of incoming text for the trigger to activate. If this parameter is not specified, the trigger will activate on any line - even if it is blank.</param>
        public static void SetTextTrigger(string name, string label, string Value)
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.SetTextOutTrigger - Creates a trigger activated when specific text is received from Client.
        /// </summary>
        /// <param name="Name">The name of the trigger to create. This name is used for later references to the trigger.</param>
        /// <param name="Label">A label within the script to jump to when the trigger is activated.</param>
        /// <param name="Value">A value that is required to be in the block of incoming text for the trigger to activate. If this parameter is not specified, the trigger will activate on any line - even if it is blank.</param>
        public static void SetTextOutTrigger(string name, string label, string Value)
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.KillAllTriggers - Terminates all triggers in the script and its included subroutines.
        /// </summary>
        public static void KillAllTriggers()
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.KillTrigger - Terminates the specified trigger.
        /// </summary>
        /// <param name="Name">The name of the trigger to kill. This name was specified hen the trigger was created.</param>
        public static void KillTrigger(string name)
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.Pause - Pauses the script's execution, allowing it to wait for its triggers to activate.
        /// </summary>
        public static void Pause()
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.Sleep (NEW) - Pauses the script's execution, but will continue after delay expires.
        /// </summary>
        /// <param name="Ticks">The number of milliseconds to wait before the delay trigger automatically activates itself.</param>
        public static void Sleep(int ticks)
        {
            //TODO:
        }
        
        
        /// <summary>
        /// Command cmd.WaitFor - Pauses script execution, waiting for specified text from server connection.
        /// </summary>
        /// <param name="Value">A value that is required to be in the block of incoming text for the trigger to activate. If this parameter is not specified, the trigger will activate on any line - even if it is blank.</param>
        public static void WaitFor(string value)
        {
            //TODO:
        }
        
        
        /// <summary>
        /// Command cmd.WaitOn - create a temporary TextTrigger using a macro.
        /// </summary>
        /// <param name="Value">A value that is required to be in the block of incoming text for the trigger to activate. If this parameter is not specified, the trigger will activate on any line - even if it is blank.</param>
        public static void WaitOn(string value)
        {
            //TODO:
        }

#endregion
#region Menu System commands

        /// <summary>
        /// Command cmd.SetMenuKey - Sets the menu key used to activate TWX.
        /// </summary>
        /// <param name="Key">A string containing the character to be used to activate the TWX main menu.</param>
        public static void SetMenuKey(string key)
        {
            SetMenuKey(key[0]);
        }
        public static void SetMenuKey(char key)
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.AddMenu - Adds a new TWX menu.
        /// </summary>
        /// <param name="parent">The name of the 'parent' menu this menu will be added to. If left blank, the menu will not be shown in the option list of any other menu in existance.</param>
        /// <param name="name">The name of the new menu being created.</param>
        /// <param name="description">The description of the menu being created. This description will be shown in the option list of the parent menu, and as a title for the new menu option list.</param>
        /// <param name="hotkey">The hotkey used to access this menu from it's parent menu.</param>
        /// <param name="reference">The script label reference to jump to when the new menu is activated.</param>
        /// <param name="prompt">The text to display inside the new menu prompt.</param>
        /// <param name="closeMenu">If TRUE, this menu will automatically close itself when it is activated. For sub-menus that contain their own list of options, this should always be set to FALSE. Default value is FLASE</param>
        public static void AddMenu(string parent, string name, string description, string hotkey, string reference, string prompt, bool closeMenu = false)
        {
            //TODO:
        }
        /// <summary>

        /// <summary>
        /// Command cmd.OpenMenu - Activates an existing script menu or TWX Terminal Menu option.
        /// </summary>
        /// <param name="name">The name of an existing menu to activate.</param>
        /// <param name="Pause">(Optional)A value of false causes the menu to display but not pause. Default valuse is true.</param>
        public static void OpenMenu(string name, bool pause = true)
        {
            //TODO:
        }

        /// Command cmd.CloseMenu - Closes the open TWX menu.
        /// </summary>
        public static void CloseMenu()
        {
            //TODO:
        }
                       
        /// <summary>
        /// Command cmd.GetMenuValue -Retrieve the display value of an existing menu.
        /// </summary>
        /// <param name="name">The name of an existing menu to activate.</param>
        /// <param name="Value">A paramater to hold the value associated with the menu.</param>
        public static void GetMenuValue(string name, Param value)
        {
            value.Update(GetMenuValue(name));
        }
                       
        public static string GetMenuValue(string name)
        {
            //TODO:
            return "";
        }

        /// <summary>
        /// Command cmd.SetMenuValue - Sets the display value of an existing menu.
        /// </summary>
        /// <param name="name">The name of an existing menu to have its value set.</param>
        /// <param name="Value">A paramater to hold the new value that will be associated with the menu.</param>
        public static void SetMenuValue(string name, Param value)
        {
            //TODO:
        }
                       
        /// <summary>
        /// Command cmd.SetMenuHelp - Sets the help display of an existing menu.
        /// </summary>
        /// <param name="name">The name of an existing menu to have its value set.</param>
        /// <param name="text">The new help text for the menu.</param>
        public static void SetMenuHelp(string name, string text)
        {
            //TODO:
        }
                       
        /// <summary>
        /// Command cmd.SetMenuOptions - Configures standard options accessible from a menu.
        /// </summary>
        /// <param name="name">The name of an existing menu to have its value set.</param>
        /// <param name="quit">{Q} Defines if the "Quit Menu" function will be accessible from within the specified menu. </param>
        /// <param name="list">{?} Defines if the "Command List" function will be accessible from within the specified menu.</param>
        /// <param name="help">{+} Defines if the "Help on Command" function will be accessible from within the specified menu.</param>
        public static void SetMenuOptions(string name, bool quit = true, bool list = true, bool help = true)
        {
            //TODO:
        }


#endregion
#region Window commands
        
        /// <summary>
        /// Command cmd.Window - Creates a script window to display information while the script is running.
        /// </summary>
        /// <param name="windowName">The name of the script window to create. The window will be referenced by this name.</param>
        /// <param name="sizeX">The width (in pixels) of the new window.</param>
        /// <param name="sizeY">The height (in pixels) of the new window.</param>
        /// <param name="title">The title to display at the top of the window.</param>
        /// <param name="ontop">If specified, the window will be set to appear on top of all other windows on the desktop.</param>
        public static void Window(string windowName, int sizeX, int sizeY, string title, bool ontop = false)
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.SetWindowContents - Sets the display content of a script window.
        /// </summary>
        /// <param name="windowName">The name of the script window to modify.</param>
        /// <param name="text">The text content to place inside the script window.</param>
        public static void SetWindowContents(string windowName, string text)
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.KillWindow - Unloads a script window.
        /// </summary>
        /// <param name="windowName">The name of the script window to close.</param>
        public static void KillWindow(string windowName)
        {
            //TODO:
        }

#endregion
#region load/save ini file commands

        /// <summary>
        /// Command cmd.LoadVar - Loads a variable from the config file associated with the current Database.
        /// </summary>
        /// <param name="var">The paramater to load from file.</param>
        public static void LoadVar(Param var)
        {
            //TODO:
        }

        /// <summary>
        /// Command SaveVar - Saves a variable to a file associated with the currently selected Database.
        /// </summary>
        /// <param name="var">The paramater to save to file.</param>
        public static void SaveVar(Param var)
        {
            //TODO:
        }

#endregion
#region Global Var commands

        /// <summary>
        /// Command cmd.LoadGlobal - Loads a variable from a global array without all that mucking around in INI files.
        /// </summary>
        /// <param name="var">The paramater to load from global memory.</param>        
        public static void LoadGlobal(Param var)
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.SaveGlobal - Saves a variable to a global array without all that mucking around in INI files.
        /// </summary>
        /// <param name="var">The paramater to save to global memory.</param>
        public static void SaveGlobal(Param var)
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.ClearGlobals - Clears all global variables from memory.
        /// </summary>
        public static void ClearGlobals()
        {
            //TODO:
        }

#endregion
#region String Manipulation commands

        /// <summary>
        /// Command cmd.CutLengths - Cuts the lengths of an array of strings.
        /// </summary>
        public static void CutLengths()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.CutText - Cuts a value out of a piece of text.
        /// </summary>
        /// ????  array <lengths1,length2,...>
        public static void CutText()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Format - Formats a string for display.
        /// </summary>
        /// Format = (CURRENCY, NUMBER, DATETIMETOSTR, STRTODATETIME)
        /// <param name="text">The text to be formatted.</param>
        /// <param name="var">The paramater to hold the formatted string.</param>
        /// <param name="format">The format to be applied (CURRENCY, NUMBER, DATETIMETOSTR, STRTODATETIME).</param>
        public static void Format(string text, Param var, string format)
        {
            var.Update(Format(text, format));
        }

        public static string Format(string text, string format)
        {
            //TODO:
            return "";
        }
                       
        /// <summary>
        /// Command cmd.GetCharCode - Retrieves an ASCII character code from a single-character value.
        /// </summary>
        /// <param name="c">The charto get a code from. This must be a single character, it cannot be a block of text.</param>
        /// <param name="var">The paramater to hold the character code.</param>
        public static void GetCharCode(char c, Param var)
        {
            var.Update(GetCharCode(c));
        }
                       
        public static string GetCharCode(char c)
        {
            //TODO:
            return "";
        }
    
        /// <summary>
        /// Command cmd.GetLength - Retrieves the length of a block of text.
        /// </summary>
        /// <param name="text">The text to be tested for its length.</param>
        /// <param name="var">The paramater to hold the character code.</param>
        public static void GetLength(string text, Param var)
        {
            var.Update(text.Length);
        }
    
        /// <summary>
        /// Command cmd.GetText - Copies a value out of a line of text by using sub strings.
        /// </summary>
        /// <param name="text">The line of text to copy a value from.</param>
        /// <param name="var">The paramater to hold the value</param>
        /// <param name="start">The position of the first character to be copied.</param>
        /// <param name="end">The position of the last character to be copied.</param>
        public static void GetText(string text, Param var, int start, int end)
        {
            var.Update(text.Substring(start, end-start));
        }
    
        /// <summary>
        /// Command cmd.GetWord - Copies a specific word out of a line of text.
        /// </summary>
        /// <param name="text">The line of text to copy a value from.</param>
        /// <param name="var">The paramater to hold the value</param>
        /// <param name="index">The index of the word to be copied.</param>
        /// <param name="default">The default value id no waor is found.</param>
        public static void GetWord(string text, Param var, int index, string defaulttext = "")
        {
            var.Update(GetWord(text, index, defaulttext));
        }
    
        public static string GetWord(string text, int index, string defaulttext = "")
        {
            string[] s = text.Split(" ");
            if (index > s.Length) return default;
            else return s[index];
        }
    
        /// <summary>
        /// Command cmd.GetWordCount - Counts the words in a string.
        /// </summary>
        /// <param name="text">The line of text to copy a value from.</param>
        /// <param name="var">The paramater to hold the value</param>
        public static void GetWordCount(string text, Param var)
        {
            var.Update(GetWordCount(text));
        }
        public static int GetWordCount(string text)
        {
            return text.Split(" ").Length;
        }
    
        /// <summary>
        /// Command cmd.GetWordPos - Finds the location of a value within a block of text.
        /// </summary>
        /// <param name="text">The line of text to copy a value from.</param>
        /// <param name="var">The paramater to hold the position.</param>
        /// <param name="value">The value to search for.</param>
        public static void GetWordPos(string text, Param var, string value)
        {
            var.Update(text.IndexOf(value));
        }
    
        /// <summary>
        /// Command cmd.LowerCase - Converts all text within a variable to lower case.
        /// </summary>
        /// <param name="var">The paramater to be converted to lowercase.</param>
        public static void LowerCase(Param var)
        {
            var.Update(((string)var).ToLower());
        }
    
        /// <summary>
        /// Command cmd.MergeText - Concatenates two text values together to form one.
        /// </summary>
        /// <param name="text1">The value to form the first part of the merged value.</param>
        /// <param name="text2">The value to form the second part of the merged value.</param>
        /// <param name="var">The paramater to hold the merged strings.</param>
        public static void MergeText(string text1, string text2, Param var)
        {
            var.Update(text1 = text2);
        }
    
        /// <summary>
        /// Command cmd.PadLeft - Add spaces to the left of a variable.
        /// </summary>
        /// <param name="var">The paramater to be padded.</param>
        public static void PadLeft(Param var)
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.PadRight - Add spaces to the right of a variable.
        /// </summary>
        /// <param name="var">The paramater to be padded.</param>
        public static void PadRight(Param var)
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.SplitText - Splits a string into an array of words.
        /// </summary>
        public static void SplitText()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.StripText - Removes a character or sub-string from a variable.
        /// </summary>
        public static void StripText()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Trim - Removes leading and trailing spaces from a string.
        /// </summary>
        public static void Trim()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.UpperCase - Converts all text within a variable to upper case.
        /// </summary>
        /// <param name="var">The paramater to be converted to upercase.</param>
        public static void UpperCase(Param var)
        {
            var.Update(((string)var).ToUpper());
        }
    
        
#endregion
#region File and Direcctory commands

    
        /// <summary>
        /// Command cmd.Delete - Deletes a file.
        /// </summary>
        public static void Delete()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.FileExists - Checks to see if a file exists.
        /// </summary>
        public static void FileExists()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetDirList - Gets a list of files from a directory.
        /// </summary>
        public static void GetDirList()
        {
            //TODO:
        }
      
        /// <summary>
        /// Command cmd.GetFileList - Populates a specified array with any files that match a specified Mask (like *.ts).
        /// </summary>
        public static void GetFileList()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.MakeDir - Creates a directory.
        /// </summary>
        public static void MakeDir()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Read - Reads a line of a text from a text file.
        /// </summary>
        public static void Read()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Write - Appends a line of text to a text file.
        /// </summary>
        public static void Write()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.RemoveDir - Removes a directory.
        /// </summary>
        public static void RemoveDir()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Rename - Renames a file.
        /// </summary>
        public static void Rename()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.ReplaceText - Replaces a value, or set of values within a variable.
        /// </summary>
        public static void ReplaceText()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.SetArray - Declares a static array.
        /// </summary>
        public static void SetArray()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.ReadToArray - Reads a text file directly into a TWX array.
        /// </summary>
        public static void ReadToArray()
        {
            //TODO:
        }
    

#endregion
#region database commands

        /// <summary>
        /// Command cmd.SetAvoid - Adds an Avoid to TWX's internal Avoid list.
        /// </summary>
        public static void SetAvoid()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.ListAvoids - Populates a user-specified array with the list of internal Avoided sectors.
        /// </summary>
        public static void ListAvoids()
        {
            //TODO:
        }
    
   
        /// <summary>
        /// Command cmd.ClearAllAvoids - Removes all sectors from TWX's internal Avoid list.
        /// </summary>
        public static void ClearAllAvoids()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.ClearAvoid - Removes a single sector from TWX's internal Avoid list.
        /// </summary>
        public static void ClearAvoid()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetAllCourses - Populates an array with coarse plots from a specified sector.
        /// </summary>
        public static void GetAllCourses()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetCourse - Internally calculates a warp course using warp data in the TWX Proxy database.
        /// </summary>
        public static void GetCourse()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetDistance - Internally calculates the distance between two sectors.
        /// </summary>
        public static void GetDistance()
        {
            //TODO:
        }
    
   
        /// <summary>
        /// Command cmd.GetNearestWarps - Populates a specified array with surrounding sectors, sorted by distance.
        /// </summary>
        public static void GetNearestWarps()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetSector - Retrieve the details of a specific sector from the TWX Proxy Database.
        /// </summary>
        public static void GetSector()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.SetSectorParameter - Sets a permanent variable, assigning it to a sector.
        /// </summary>
        public static void SetSectorParameter()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetSectorParameter - Retrieves a permanent user specified variable assigned to a sector.
        /// </summary>
        public static void GetSectorParameter()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.ListSectorParameters - Populates an array with the list of Sector Parameters for a sector.
        /// </summary>
        public static void ListSectorParameters()
        {
            //TODO:
        }
    
    
    
    
#endregion
#region Misc commands
     
        /// <summary>
        /// Command cmd.GetDate - Retrieves the date and stores it in a variable.
        /// </summary>
        public static void GetDate()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetTime - Retrieves the current system time, or a formatted date/time value.
        /// </summary>
        public static void GetTime()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetTimer - Retrieves the number of CPU ticks since power on.
        /// </summary>
        public static void GetTimer()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetRnd - Generate a random number within a specified range.
        /// </summary>
        public static void GetRnd()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetScriptVersion - Reports the version of the compiler used for a compiled script. (*.cts)
        /// </summary>
        public static void GetScriptVersion()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Logging - Disables or enables TWX Proxy's logging feature while the script is running.
        /// </summary>
        public static void Logging()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.SystemScript - Sets the script as a "systemScript", allowing it to run in the background .
        /// </summary>
        public static void SystemScript()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.ReqRecording - Ensures that data recording is turned ON.
        /// </summary>
        public static void ReqRecording()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Truncate - Calculates the integral part of a specified decimal number.
        /// </summary>
        public static void Truncate()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Round - Rounds a variable to the specified precision.
        /// </summary>
        public static void Round()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.SetPrecision - Sets the maximum precision for decimal calculations.
        /// </summary>
        public static void SetPrecision()
        {
            //TODO:
        }
    
    
        
#endregion    
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
