using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWXP
{
    public partial class Scripts
    {

        public void CompileFromArray(Script Script, string[] ScriptText)
        {
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

        //public void CompileFromStrings(Script Script, List<string> ScriptText)
        //{
        //    int Line = 1;
        //    try
        //    {
        //        foreach (string TextLine in ScriptText)
        //        {
        //            CompileLine(Script, Line, TextLine);

        //            Line++;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        //throw;
        //    }

        //    Script.Exec();
        //}

        private void CompileLine(Script script, int line, string textline)
        {
            if (textline.Substring(0, 1) == ":")
            {
                script.Labels.Add(new Label(textline));
            }
            else
            {
                //TODO: Macros
                Params param = ParseParameters(script, textline);

                script.scrcmds.Add(new ScriptCmd(script, param));
            }
        }

        private Params ParseParameters(Script script, string textline)
        {
            Params param = new Params();

            bool InQuotes = false;

            foreach(string s in textline.Split('"'))
            {
                if (InQuotes)
                {
                    param.Add(new Param(script, s));
                    InQuotes = false;
                }
                else
                {
                    foreach (string p in s.Split(' '))
                        if (p.Length > 0)
                            param.Add(new Param(script, p));
                    InQuotes = true;
                }

            }
            return param;
        }
    }
}
