//namespace HighCode.Presentation.Utils;

using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CSharp;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using NUnit.Framework.Constraints;

public class UnitTestExecutor
{
    public async static Task<string> Execute(string code)
    {
        // Создание сборки из исходного кода
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
        string assemblyName = Path.GetRandomFileName();
        MetadataReference[] references =
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location), 
            MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location), 
            MetadataReference.CreateFromFile(typeof(Assert).Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location),
        };
        CSharpCompilation compilation = CSharpCompilation.Create(assemblyName, new[] { syntaxTree }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        Assembly? resultAssembly = null;
        var sb = new StringBuilder();
        // Проверка наличия ошибок компиляции
        using (var ms = new MemoryStream())
        {
            var result = compilation.Emit(ms);
            if (!result.Success)
            {
                sb.AppendLine("🤡Ошибки:");
                foreach (var diagnostic in result.Diagnostics)
                {
                    sb.AppendLine(diagnostic.GetMessage());
                }

                return sb.ToString();
            }
            else
            {
                ms.Seek(0, SeekOrigin.Begin);
                resultAssembly = Assembly.Load(ms.ToArray());
            }
        }
        
        Assembly testAssembly = resultAssembly;
        foreach (Type type in testAssembly.GetTypes())
        {
            foreach (MethodInfo method in type.GetMethods())
            {
                if (Attribute.IsDefined(method, typeof(NUnit.Framework.TestAttribute)))
                {
                    object instance = Activator.CreateInstance(type);
                    try
                    {
                        method.Invoke(instance, null);
                        sb.AppendLine($"{method.Name}: ✅Passed");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine($"{method.Name}: 🤡Failed - {ex.InnerException.Message}");
                    }
                }
            }
        }

        return sb.ToString();
    }

}