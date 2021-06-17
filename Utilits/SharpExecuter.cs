using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpTests
{
    public delegate void ExecuteLogHandler(object message);

    public class SharpExecuter
    {
        string formatedProgramText;

        public static ExecuteLogHandler OnExecute;

        public List<string> References { get; set; }
        public List<string> Usings { get; set; }

        readonly string log = 
            "static void Log(object message) " +
            "{ " +
                "if (SharpTests.SharpExecuter.OnExecute != null) " +
                    "SharpTests.SharpExecuter.OnExecute(message); " +
            "}";

        public SharpExecuter()
        {
            References = new List<string>();
            Usings = new List<string>();

            References.AddRange(new string[]
            {
                "System.dll",
                "System.Core.dll",
                "System.Net.dll",
                "System.Data.dll",
                "System.Drawing.dll",
                "System.Windows.Forms.dll",
                Assembly.GetAssembly(typeof(SharpExecuter)).Location,
            });

            Usings.AddRange(new string[]
            {
                "System",
                "System.IO",
                "System.Net",
                "System.Threading",
                "System.Collections.Generic",
                "System.Text",
                "System.Text.RegularExpressions",
                "System.ComponentModel",
                "System.Data",
                "System.Drawing",
                "System.Diagnostics",
                "System.Linq",
                "System.Windows.Forms",
                "System.Threading",
                "System.Threading.Tasks"
        });
        }

        public void Execute(string code)
        {
            code = FormatSources(code);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters compilerParams = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };

            compilerParams.ReferencedAssemblies.AddRange(References.ToArray());
            CompilerResults compilerResult = provider.CompileAssemblyFromSource(compilerParams, code);

            if (compilerResult.Errors.Count == 0)
            {
                compilerResult.CompiledAssembly.GetType("SharpTests.Program").GetMethod("Main").Invoke(null, null);
            }
            else
            {
                foreach (var item in compilerResult.Output)
                {
                    OnExecute(item);
                }
            }
        }

        public string FormatSources(string text)
        {
            string usings = FormatUsings();
            text = FormatCode(text);
            formatedProgramText = string.Concat(usings, text);
            return formatedProgramText;
        }

        private string FormatUsings()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string item in Usings)
            {
                sb.AppendFormat($"using {item};\n");
            }
            return sb.ToString();
        }

        private string FormatCode(string text)
        {
            //text = text.Replace("Console.WriteLine(", "LogLine(");

            text = text.Replace("Console.WriteLine(", "Log(");

            text = text.Insert(text.Length - 4, log);

            return text;
        } 
    }
}
