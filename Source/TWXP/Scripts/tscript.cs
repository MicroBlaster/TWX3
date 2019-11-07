﻿using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TWXP
{
    public class TScript
    {
        // Public Read-only Properties
        public string FileName { get; private set; }
        public Proxy Proxy { get; private set; }
        public bool Silent { get; private set; }
        public List<Param> Vars { get; private set; }
        //public List<CmdParam> ParamList { get; private set; }
        //public List<string> IncludeList { get; private set; }
        //public List<Label> LabelList { get; private set; }

        private List<CommandLine> commandlist = new List<CommandLine>();
        //private List<CmdParam> cmdParamlist = new List<CmdParam>();
        private List<CmdParam> paramlist = new List<CmdParam>();
        private List<string> includelist = new List<string>();
        private List<Label> labellist = new List<Label>();

        /// <summary>
        /// Creates a new script.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="silent">Run script in silent mode.</param>
        public TScript(string filename, Proxy proxy, bool silent = false)
        {
            FileName = filename;
            Proxy = proxy;
            Silent = silent;

            Vars = new List<Param>();
        }

        public void Exec()
        {
            // Loop through each command until the end is reached or Halt Is called.
            foreach (CommandLine cl in commandlist)
            {
                // Invoke the referenced command.
                //Commands CmdRef = new Commands();
                cl.Invoke();
            }
        }

        public void ReadCTS()
        {
            FileHeader hdr;

            //cmdParamlist = new List<CmdParam>();

            if (!File.Exists(FileName))
            {
                // TODO: Report and Log Error
                Debug.WriteLine("Invalid fliename");
                return;
            }

            FileInfo path = new FileInfo(FileName);

            using (BinaryReader stream = new BinaryReader(path.OpenRead()))
            {
                var bs = stream.BaseStream;

                hdr = new FileHeader(stream);

                if (hdr.FileType != "TWX SCRIPT")
                {
                    Debug.WriteLine($"Error: This is not a compiled TWX script.");
                    return;
                }

                if (hdr.Version < 3 || hdr.Version > 6)
                {
                    Debug.WriteLine($"Error: Invalid Script Version {hdr.Version}, unable to read.");
                    return;
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

                using (BinaryReader codeRef = new BinaryReader(ms))
                {
                    // Loop through the main CodeBase
                    bs = codeRef.BaseStream;
                    while (bs.Position < bs.Length)
                    {
                        // Add each command to the CommandList
                        commandlist.Add(new CommandLine(this, codeRef));
                    }
                }
            }
        }
        public enum ParamType { CMD, VAR, CONST, SYSCONST, PROGVAR, CHAR }

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
                if (isVar) Name = ReadString(stream, stream.ReadInt32()).ToLower();
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
                    return System.Text.Encoding.Default.GetString(result.ToArray()).Replace("\r", "*");
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
                Name = Encoding.UTF8.GetString(stream.ReadBytes(length), 0, length).Replace(":", "LAB_");

                Debug.Write($"label: {Name} = {Location}\n");
            }
        }

        public class CommandLine
        {
            public string Name { get; private set; }
            public byte ScriptID { get; private set; }
            public uint CodeLine { get; private set; }
            public uint CmdIndex { get; private set; }
            public Command CmdRef { get; private set; }
            //public Script Script { get; private set; }
            public List<Param> Param { get; private set; }
            private TScript script;

            public CommandLine(TScript script, BinaryReader stream)
            {
                this.script = script;

                ScriptID = stream.ReadByte();
                CodeLine = stream.ReadUInt16();
                CmdIndex = stream.ReadUInt16();

                Param = new List<Param>();

                CmdRef = cmd.Commands[(int)CmdIndex];
                Name = CmdRef.Name;


                Debug.Write($"Command: {ScriptID}:{CodeLine}:{CmdIndex}:{Name}\n");

                while (true)
                {
                    var pt = stream.ReadByte();
                    switch (pt)
                    {
                        case (byte)ParamType.CMD:
                            return;

                        case (byte)ParamType.VAR:
                            Param.Add(new Param(script, ReadVar(stream), true));
                            break;

                        case (byte)ParamType.CONST:
                            Param.Add(new Param(script, ReadConst(stream)));
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

                string name = script.paramlist[VarRef].Name;

                for (int i = 0; i < IndexCount; i++)
                {

                }

                //if (Param.Where(p => p.VarName == name).Count() == 0)
                //{
                //    Param.Add(new Param(name, null));
                //}
                Debug.Write($"Param: VAR = {name}\n");
                return name;
            }

            string ReadConst(BinaryReader stream)
            {
                int VarRef = stream.ReadInt32();
                string name = script.paramlist[VarRef].Name;
                string value = script.paramlist[VarRef].Value;
                decimal dv;

                //byte IndexCount = stream.ReadByte();
                if (!decimal.TryParse(value, out dv))
                {
                    value = "\"" + value + "\"";
                }

                //var param = Param.Where(p => p.VarName == name);
                //if (param.Count() == 0)
                //{
                //    Param.Add(new Param(name, value));
                //}
                //else
                //{
                //    param.First().Update(value);
                //}

                Debug.Write($"Param: CONST {name} = {value}\n");
                return value;
            }

            // Invoke this command line
            public void Invoke()
            {
                switch (Name)
                {
                    case "Branch":
                        //TODO:
                        return;

                    case "Goto":
                        //TODO
                        return;

                    default:
                        foreach (Param p in Param)
                        {
                            IEnumerable<Param> vars;
                            if (p.IsVarable)
                            {
                                vars = script.Vars.Where(v => v.VarName.ToLower() == p.VarName.ToLower());
                            }
                            else
                            {
                                vars = script.Vars.Where(v => v.VarName.ToLower() == p.Value.ToLower());
                            }

                            if (vars.Count() > 0)
                            {
                                p.Update(vars.Single().Value);
                            }
                        }
                        
                        CmdRef.Invoke(script, Param.ToArray());
                        return;
                }
            }

        }
    }
}
