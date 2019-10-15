using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWXP
{
    partial class Scripts
    {
        public struct ScriptHeader
        {
            public string[] ProgramName;
            public ushort Version;
            public int DescSize;
            public int CodeSize;
        }

        public void LoadFromFile(string Filename)
        {
            ScriptHeader Hdr;

        }
    }
}
