using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWXP
{
    public partial class Scripts
    {

        public void CompileFromStrings(Script Script, List<string> ScriptText)
        {
            //byte ScriptID;
            //int Line;
            //int I;
            //string ParamStr;
            //string LineText;
            //char Last;
            //bool Linked;
            //bool InQuote;
            //List<string> ParamLine = new List<string>();
            

            int Line = 1;
            try
            {
                foreach (string TextLine in ScriptText)
                {
                    CompileLine(Script, Line, TextLine);

                    Line++;
                }
            }
            catch (Exception e)
            {

                //throw;
            }

            Script.Exec();
        }

        private void CompileLine(Script script, int line, string textline)
        {
            if (textline.Substring(0, 1) == ":")
            {
                script.Labels.Add(new Label(textline));
            }
            else
            {
                //TODO: Macros
                Parameters param = ParseParameters(textline);

                script.Commands.Add(new ScriptCommand(script, param));
            }
        }

        private Parameters ParseParameters(string textline)
        {
            Parameters param = new Parameters();

            bool InQuotes = false;

            foreach(string s in textline.Split('"'))
            {
                if (InQuotes)
                {
                    param.Add(new Parameter(s));
                    InQuotes = false;
                }
                else
                {
                    foreach (string p in s.Split(' '))
                        if (p.Length > 0)
                            param.Add(new Parameter(p));
                    InQuotes = true;
                }

            }
            return param;
        }
    }
}
