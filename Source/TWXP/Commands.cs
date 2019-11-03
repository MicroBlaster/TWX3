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
        public static void GetInput(param var, string prompt)
        {
            //TODO:
        }

        public static param GetInput(string prompt)
        {
            //TODO:
        }

        
        /// <summary>
        /// Command cmd.GetConsoleInput - Get input from a connected terminal without sending it.
        /// </summary>
        /// <param name="var">The paramater to hold the line of text entered by the user.</param>
        /// <param name="prompt">The text to display above the input prompt.</param>
        /// <param name="singleKey">.</param>
        /// For backwards compatability, any value for the singleKey parameter will be interperted as true.
        public static void GetConsoleInput(param var, string prompt, bool singleKey = false)
        {
            var.update(GetConsoleInput(prompt, singlekey);
        }

        public static param GetConsoleInput(string prompt, bool singleKey = false)
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.GetOuttext - Retrieve any outgoing text from TWX Proxy's outgoing buffer.
        /// </summary>
        /// <param name="var">The paramater to hold the outgoing text.</param>
        public static void GetOuttext(param var)
        {
            var.update(GetOuttext());
        }

        public static param GetOuttext()
        {
            //TODO:
        }

        
        /// <summary>
        /// Command cmd.ProcessIn  - Emulates incoming text from the remote server, activating TextLine triggers.
        /// </summary>
        public static void ProcessIn ()
        {
            //TODO:
        }

        
        /// <summary>
        /// Command cmd.ProcessOut  - Resumes processing out outgoing data that was trapped by a TextOutTrigger.
        /// </summary>
        public static void ProcessOut ()
        {
            //TODO:
        }

        
        
        /// <summary>
        /// Command cmd.GetDeafClients  - Retreives the status of any deaf clients.
        /// </summary>
        public static void GetDeafClients()
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.SetDeafClients - Sets the deaf status on all clients.
        /// </summary>
        public static void SetDeafClients()
        {
            //TODO:
        }

        
        
        
#endregion
#region Delay and Trigger commands
     
        /// <summary>
        /// Command cmd.setDelayTrigger - Creates a trigger that will activate after a specified time period.
        /// </summary>
        public static void SetDelayTrigger()
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.SetEventTrigger - Creates a trigger that will activate on a certain program event.
        /// </summary>
        public static void SetEventTrigger()
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.SetTextLineTrigger - Creates a trigger activated when specific text is received from Server.
        /// </summary>
        public static void SetTextLineTrigger()
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.SetTextTrigger - Creates a text trigger activated when specific text is received.
        /// </summary>
        public static void SetTextTrigger()
        {
            //TODO:
        }
        
        /// <summary>
        /// Command cmd.SetTextOutTrigger - Creates a trigger activated when specific text is received from Client.
        /// </summary>
        public static void SetTextOutTrigger()
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
        public static void KillTrigger()
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
        public static void Sleep()
        {
            //TODO:
        }
        
        
        /// <summary>
        /// Command cmd.WaitFor - Pauses script execution, waiting for specified text from server connection.
        /// </summary>
        public static void WaitFor()
        {
            //TODO:
        }
        
        
        /// <summary>
        /// Command cmd.WaitOn - create a temporary TextTrigger using a macro.
        /// </summary>
        public static void WaitOn()
        {
            //TODO:
        }

#endregion
#region Menu System commands

        /// <summary>
        /// Command cmd.SetMenuKey - Sets the menu key used to activate TWX.
        /// </summary>
        public static void SetMenuKey()
        {
            //TODO:
        }
        /// <summary>
        /// Command cmd.AddMenu - Adds a new TWX menu.
        /// </summary>
        public static void AddMenu()
        {
            //TODO:
        }
        /// <summary>
        /// Command cmd.CloseMenu - Closes the open TWX menu.
        /// </summary>
        public static void CloseMenu()
        {
            //TODO:
        }
        /// <summary>
        /// Command cmd.GetMenuValue -Retrieve the display value of an existing menu.
        /// </summary>
        public static void GetMenuValue()
        {
            //TODO:
        }
        /// <summary>
        /// Command cmd.OpenMenu - Activates an existing script menu or TWX Terminal Menu option.
        /// </summary>
        public static void OpenMenu()
        {
            //TODO:
        }
        /// <summary>
        /// Command cmd.SetMenuHelp - Sets the help display of an existing menu.
        /// </summary>
        public static void SetMenuHelp()
        {
            //TODO:
        }
        /// <summary>
        /// Command cmd.SetMenuOptions - Configures standard options accessible from a menu.
        /// </summary>
        public static void SetMenuOptions()
        {
            //TODO:
        }
        /// <summary>
        /// Command cmd.SetMenuValue - Sets the display value of an existing menu.
        /// </summary>
        public static void SetMenuValue()
        {
            //TODO:
        }


#endregion
#region Window commands
        
        /// <summary>
        /// Command cmd.Window - Creates a script window to display information while the script is running.
        /// </summary>
        public static void Window()
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.SetWindowContents - Sets the display content of a script window.
        /// </summary>
        public static void SetWindowContents()
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.KillWindow - Unloads a script window.
        /// </summary>
        public static void KillWindow()
        {
            //TODO:
        }

#endregion
#region load/save ini file commands

        /// <summary>
        /// Command cmd.LoadVar - Loads a variable from the config file associated with the current Database.
        /// </summary>
        public static void LoadVar()
        {
            //TODO:
        }

        /// <summary>
        /// Command SaveVar - Saves a variable to a file associated with the currently selected Database.
        /// </summary>
        public static void SaveVar()
        {
            //TODO:
        }

#endregion
#region Global Var commands

        /// <summary>
        /// Command cmd.LoadGlobal - Loads a variable from a global array without all that mucking around in INI files.
        /// </summary>
        public static void LoadGlobal()
        {
            //TODO:
        }

        /// <summary>
        /// Command cmd.SaveGlobal - Saves a variable to a global array without all that mucking around in INI files.
        /// </summary>
        public static void SaveGlobal()
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
        public static void CutText()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Format - Formats a string for display.
        /// </summary>
        public static void Format()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetCharCode - Retrieves an ASCII character code from a single-character value.
        /// </summary>
        public static void GetCharCode()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetLength - Retrieves the length of a block of text.
        /// </summary>
        public static void GetLength()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetText - Copies a value out of a line of text by using sub strings.
        /// </summary>
        public static void GetText()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetWord - Copies a specific word out of a line of text.
        /// </summary>
        public static void GetWord()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetWordCount - Counts the words in a string.
        /// </summary>
        public static void GetWordCount()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.GetWordPos - Finds the location of a value within a block of text.
        /// </summary>
        public static void GetWordPos()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.LowerCase - Converts all text within a variable to lower case.
        /// </summary>
        public static void LowerCase()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.MergeText - Concatenates two text values together to form one.
        /// </summary>
        public static void MergeText()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.PadLeft - Add spaces to the left of a variable.
        /// </summary>
        public static void PadLeft()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.PadRight - Add spaces to the right of a variable.
        /// </summary>
        public static void PadRight()
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
        public static void UpperCase()
        {
            //TODO:
        }
    
        
#endregion
#region File and Direcctory commands

        /// <summary>
        /// Command cmd.
        /// </summary>
        public static void cmd()
        {
            //TODO:
        }
    
        /// <summary>
        /// Command cmd.Delete - Deletes a file.
        /// </summary>
        public static void cmd()
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
        /// Command cmd.
        /// </summary>
        public static void cmd()
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
        /// Command cmd.
        /// </summary>
        public static void cmd()
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
        /// Command cmd.
        /// </summary>
        public static void cmd()
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
