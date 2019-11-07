using System;
using System.IO;
using System.Windows;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.VisualBasic;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.Loader;
using System.Collections.Generic;

namespace TWXP
{
    public partial class Scripts : List<Script>
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public string FileName { get; private set; }
        private Proxy proxy;

        public Scripts(Proxy proxy)
        {
            this.proxy = proxy;
            cmd.Load();
        }

        private delegate void SayAnything();

        public string Load(string filename)
        {
            FileName = $"{AssemblyDirectory}\\{filename}";

            string source = "";

            switch (Path.GetExtension(filename))
            {
                case ".vb":
                    Compilation vbCompilation = CompileVB();
                    if (vbCompilation != null) Exec(vbCompilation);
                    break;

                case ".cs":
                    Compilation csCompilation = CompileCS();
                    if (csCompilation != null) Exec(csCompilation);
                    break;

                case ".cts":
                    // TODO: See if the script is already running.
                    TScript tscript = new TScript(FileName, proxy);
                    tscript.ReadCTS();
                    tscript.Exec();
                    break;
            }
            return source;
        }

        public void Compile(string source)
        {
            //Compilation vbCompilation = CompileVB(source);
            //if (vbCompilation != null) Exec(vbCompilation);
            Compilation csCompilation = CompileCS(source);
            if (csCompilation != null) Exec(csCompilation);
        }

        private Compilation CompileVB()
        {
            //CSharpCompilation cs; 

            if (!File.Exists(FileName))
            {
                // TODO: Report and Log Error
                Debug.WriteLine("Invalid Filename");
                return null;
            }

            return CompileVB(File.ReadAllText(FileName));
        }

        private Compilation CompileVB(string source)
        {


            var syntaxTree = VisualBasicSyntaxTree.ParseText(source);
            string assemblyName = Guid.NewGuid().ToString();

            var references = new MetadataReference[]
           {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Microsoft.VisualBasic.CallType).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.IO.File).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(TWXP.cmd).Assembly.Location)
           };

            return VisualBasicCompilation.Create(
                assemblyName,
                new[] { syntaxTree },
                references,
                new VisualBasicCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }

        private Compilation CompileCS()
        {
            //CSharpCompilation cs; 

            if (!File.Exists(FileName))
            {
                // TODO: Report and Log Error
                Debug.WriteLine("Invalid Filename");
                return null;
            }
            return CompileCS(File.ReadAllText(FileName));
        }

        private Compilation CompileCS(string source)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(source);
            string assemblyName = Guid.NewGuid().ToString();

            var references = new MetadataReference[]
           {
//MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("System.Runtime")).Location),
//MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("mscorlib")).Location)),

                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.IO.File).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(TWXP.cmd).Assembly.Location)
           };

            return CSharpCompilation.Create(
                assemblyName,
                new[] { syntaxTree },
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }

        private void Exec(Compilation compilation)
        {
            var context = new LoadContext();

            using (var ms = new MemoryStream())
            {
                var cr = compilation.Emit(ms);
                if (cr.Success)
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    var assembly = context.LoadFromStream(ms);

                    var type = assembly.GetType("Script");
                    var greetMethod = type.GetMethod("Main");

                    //var instance = Activator.CreateInstance(type);
                    var result = greetMethod.Invoke(null, null);

                }
            }

            context.Unload();
        }

        internal class LoadContext : AssemblyLoadContext
        {
            public LoadContext()
                : base(true)
            {
            }

            protected override Assembly Load(AssemblyName assemblyName)
            {
                return null;
            }
        }
    }

    public class Script
    {

    }
}