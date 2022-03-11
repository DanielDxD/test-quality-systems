using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;

public static class EvalProvider
{
    public static Func<T, TResult> CreateEvalMethod<T, TResult>(string code, string[] usingStatements = null, string[] assemblies = null)
    {
        Type returnType = typeof(TResult);
        Type inputType = typeof(T);

        var includeUsings = new HashSet<string>(new[] { "System", "System.Linq", "Utils" });
        includeUsings.Add(returnType.Namespace);
        includeUsings.Add(inputType.Namespace);
        if (usingStatements != null)
            foreach (var usingStatement in usingStatements)
                includeUsings.Add(usingStatement);

        using (CSharpCodeProvider compiler = new CSharpCodeProvider())
        {
            var name = "F" + Guid.NewGuid().ToString().Replace("-", string.Empty);
            var includeAssemblies = new HashSet<string>();

            foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    string location = assembly.Location;

                    if (!String.IsNullOrEmpty(location))
                        includeAssemblies.Add(location);
                    else { }
                }
                catch (NotSupportedException)
                {
                    // this happens for dynamic assemblies, so just ignore it. 
                }
            }

            var parameters = new CompilerParameters(includeAssemblies.ToArray())
            {
                IncludeDebugInformation = false,
                //TempFiles = new TempFileCollection(Environment.GetEnvironmentVariable("TEMP"), true),
                GenerateInMemory = true //false //default
            };

            string source = string.Format
            (
                @" 
                    {0} 
                    namespace {1} 
                    {{ 
                        public static class EvalClass 
                        {{ 
                            public static {2} Eval({3} arg) 
                            {{ 
                                {4} 
                            }} 
                        }} 
                    }}
                ",
                GetUsing(includeUsings),
                name,
                returnType.Name,
                inputType.Name,
                (code + (code.EndsWith(";")? "" : ";"))
            );

            Func<T, TResult> result = null;

            var compilerResult = compiler.CompileAssemblyFromSource(parameters, source);

            if (!compilerResult.Errors.HasErrors)
            {
                var compiledAssembly = compilerResult.CompiledAssembly;
                var type = compiledAssembly.GetType(string.Format("{0}.EvalClass", name));
                var method = type.GetMethod("Eval");
                result = (Func<T, TResult>)Delegate.CreateDelegate(typeof(Func<T, TResult>), method);
            }
            else
            {
                for (int i = 0; i < compilerResult.Errors.Count; i++)
                    Utils.Utils.WriteLog(compilerResult.Errors[i].ToString());
            }

            return result;
        }
    }

    private static string GetUsing(HashSet<string> usingStatements)
    {
        StringBuilder result = new StringBuilder();
        foreach (string usingStatement in usingStatements)
        {
            result.AppendLine(string.Format("using {0};", usingStatement));
        }
        return result.ToString();
    }
}
