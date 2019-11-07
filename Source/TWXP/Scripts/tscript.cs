using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TWXP
{
    partial class Scripts
    {
        public enum ParamType { CMD, VAR, CONST, SYSCONST, PROGVAR, CHAR }

        //static List<CmdParam> cmdParamlist;
        static List<CmdParam> paramlist;
        static List<string> includelist;
        static List<Label> labellist;

        public class FileHeader
        {
            public string FileType { get; private set; }
            public string Description { get; private set; }
            public int Version { get; private set; }
            public int DescSize { get; private set; }
            public int CodeSize { get; private set; }

            

            public FileHeader(BinaryReader stream)
            {
                FileType = Encoding.UTF8.GetString(stream.ReadBytes(12), 0, 12).Replace("\n", "").Replace("\0", "");
                Version = stream.ReadInt32();
                DescSize = stream.ReadInt32();
                CodeSize = stream.ReadInt32();

                if (DescSize > 0)
                {
                    Description = Encoding.UTF8.GetString(stream.ReadBytes(DescSize), 0, DescSize);
                }
            }
        }

        public class CmdParam
        {
            public string Name { get; private set; }
            public string Value { get; private set; }

            public CmdParam(BinaryReader stream, bool isVar = false)
            {
                Value = ReadString(stream, stream.ReadInt32());
                if (isVar) Name =  ReadString(stream, stream.ReadInt32()).ToLower().Replace("$$","VAR_").Replace("$","");
                Debug.Write($"var: {Name} = {Value}\n");
            }

            public static string ReadString(BinaryReader stream, int size)
            {
                byte Key = 113;
                byte[] Value = stream.ReadBytes(size);

                List<byte> result = new List<byte>();

                if (Value.Length > 0)
                {
                    for (int i = 0; i < Value.Length; i++)
                    {
                        result.Add((byte)(Value[i] ^ Key));
                    }
                    return System.Text.Encoding.Default.GetString(result.ToArray()).Replace("\r","*");
                }
                else
                {
                    return null;
                }
            }

        }

        public class Label
        {
            public string Name { get; private set; }
            public int Location { get; private set; }

            public Label(BinaryReader stream)
            {
                Location = stream.ReadInt32();
                int length = stream.ReadInt32();
                Name = Encoding.UTF8.GetString(stream.ReadBytes(length), 0, length).Replace(":","LAB_");

                Debug.Write($"label: {Name} = {Location}\n");
            }
        }

        public class CommandLine
        {
            // Implicit operator to cast a parameter to a string.
            public static implicit operator string(CommandLine cl)
            {
                // Build the line from the command and paramater strings.
                string line;

                switch (cl.Name)
                {
                    case "Branch":
                        line = $"if  (!{cl.Param[0]}) goto {cl.Param[1].Replace("\"", "").Replace("::", "LAB_").Replace(":","")}";
                        return line;

                    case "Goto":
                        line = $"goto {cl.Param[0].Replace("\"", "").Replace("::", "LAB_").Replace(":", "")}";
                        return line;

                    case "SetVar":
                        line = cl.Param[0] + " = " + cl.Param[1];
                        return line;

                    default:
                        line = "cmd." + cl.Name;
                        if (cl.Param.Count > 0)
                        {
                            line += "(";
                            foreach (string p in cl.Param)
                            {
                                line += p + ", ";
                            }
                            line = line.Substring(0, line.Length - 2) + ")";
                        }
                        return line;
                }
            }


            public string Name { get; private set; }
            public byte ScriptID { get; private set; }
            public uint CodeLine { get; private set; }
            public uint CmdIndex { get; private set; }
            public List<string> Param  { get; private set; }

            public CommandLine(BinaryReader stream)
            {
                ScriptID = stream.ReadByte();
                CodeLine = stream.ReadUInt16();
                CmdIndex = stream.ReadUInt16();

                Param = new List<string>();

                Name = cmd.Commands[(int)CmdIndex].Name;


                Debug.Write($"Command: {ScriptID}:{CodeLine}:{CmdIndex}:{Name}\n");

                while (true)
                {
                    var pt = stream.ReadByte();
                    switch (pt)
                    {
                        case (byte)ParamType.CMD:
                            return;

                        case (byte)ParamType.VAR:
                            Param.Add(ReadVar(stream));
                            break;

                        case (byte)ParamType.CONST:
                            Param.Add(ReadConst(stream));
                            break;

                        case (byte)ParamType.SYSCONST:
                            break;

                        case (byte)ParamType.PROGVAR:
                            break;

                        case (byte)ParamType.CHAR:
                            break;

                    }
                }
            }

            string ReadVar(BinaryReader stream)
            {
                int VarRef = stream.ReadInt32();
                byte IndexCount = stream.ReadByte();

                string name = paramlist[VarRef].Name;

                for (int i = 0; i < IndexCount; i++)
                {

                }

                Debug.Write($"Param: VAR = {name}\n");
                return name;
            }

            string ReadConst(BinaryReader stream)
            {
                int VarRef = stream.ReadInt32();
                string value = paramlist[VarRef].Value;
                decimal dv;

                //byte IndexCount = stream.ReadByte();
                if (!decimal.TryParse(value, out dv))
                {
                    value = "\"" + value + "\"";
                }
                    

                Debug.Write($"Param: CONST = {value}\n");
                return value;
            }
        }


        public MemoryStream ReadCTS()
        {
            FileHeader hdr;

            //cmdParamlist = new List<CmdParam>();
            paramlist = new List<CmdParam>();
            includelist = new List<string>();
            labellist = new List<Label>();

            if (!File.Exists(FileName))
            {
                // TODO: Report and Log Error
                Debug.WriteLine("Invalid Filename");
                return null;
            }

            FileInfo path = new FileInfo(FileName);

            using (BinaryReader stream = new BinaryReader(path.OpenRead()))
            {
                var bs = stream.BaseStream;

                hdr = new FileHeader(stream);

                if (hdr.FileType != "TWX SCRIPT")
                {
                    Debug.WriteLine($"Error: This is not a compiled TWX script.");
                    return null;
                }

                if (hdr.Version < 3 || hdr.Version > 6)
                {
                    Debug.WriteLine($"Error: Invalid Script Version {hdr.Version}, unable to read.");
                    return null;
                }

                byte[] Code = stream.ReadBytes(hdr.CodeSize);
                MemoryStream ms = new MemoryStream(Code);

                byte type;
                do
                {
                    type = stream.ReadByte();

                    switch (type)
                    {
                        case 1:
                            paramlist.Add(new CmdParam(stream));
                            break;

                        case 2:
                            paramlist.Add(new CmdParam(stream, true));
                            break;
                    }
                } while (type > 0);

                int length;
                do
                {
                    length = 0;
                    if (bs.Position < bs.Length)
                    {
                        length = stream.ReadInt32();
                        if (length > 0)
                        {
                            includelist.Add(new string(Encoding.UTF8.GetString(stream.ReadBytes(length), 0, length)));
                        }
                    }
                } while (length > 0);

                while (bs.Position < bs.Length)
                {
                    // Load a label from the stream
                    Label label = new Label(stream);

                    // Create a new label if there isn't already a label by that name
                    if (labellist.Where(l => l.Name == label.Name).Count() == 0)
                    {
                        labellist.Add(label);
                    }
                }

                stream.Close();
                return ms;
            }
            
        }


        public string WriteCS(MemoryStream stream)
        {
            StringBuilder output = new StringBuilder();

            output.Append("using System;\nusing System.IO;\nusing TWXP;\n\n" +
                "public class Script\n{\n    public static void Main()\n    {\n");

            foreach(CmdParam p in paramlist)
            {
                if(p.Value == "0" && !string.IsNullOrEmpty(p.Name))
                {
                    output.Append("        Param " + p.Name + " = new Param();\n");
                }
            }
            output.Append("\n");

            using (BinaryReader codeRef = new BinaryReader(stream))
            {
                var bs = codeRef.BaseStream;
                //byte ScriptID = codeRef.ReadByte();


                while (bs.Position < bs.Length)
                {
                    GetLabels(bs.Position, output);

                    CommandLine cl = new CommandLine(codeRef);
                    //uint codeline = cl.CodeLine;
                    
                    output.Append("        " + cl + ";\n");
                }

                GetLabels(bs.Position, output);

            }

            output.Append("    }\n}\n");
            return output.ToString();
        }

        private void GetLabels(long pos, StringBuilder output)
        {
            var labels = labellist.Where(l => l.Location == pos);
            if (labels.Count() > 0)
            {
                foreach (Label l in labels)
                {
                    output.Append(l.Name + ":\n");
                }
            }

        }

        public string WriteVB(MemoryStream stream)
        {
            StringBuilder output = new StringBuilder();

            output.Append("Imports System\nImports System.IO\nImports TWXP\n\n" +
                "Module Script\n    Public Sub Main()\n");
 
            foreach (CmdParam p in paramlist)
            {
                if (p.Value == "0")
                {
                    //output.Append("        Dim " + p.Name + " = \"\"\n");
                    output.Append("        Dim " + p.Name + "\n");
                }
            }
            output.Append("\n");

            using (BinaryReader codeRef = new BinaryReader(stream))
            {
                var bs = codeRef.BaseStream;
                //byte ScriptID = codeRef.ReadByte();

                while (bs.Position < bs.Length)
                {
                    CommandLine cl = new CommandLine(codeRef);
                    output.Append("        " + cl + "\n");
                }
            }

            output.Append("    End Sub\nEnd Module\n");
            return output.ToString();
        }


    }

}
