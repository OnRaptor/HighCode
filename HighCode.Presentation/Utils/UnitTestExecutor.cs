//namespace HighCode.Presentation.Utils;

using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using HighCode.Presentation.Models;
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
    public async static Task<TestExecutionReport> Execute(string code)
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
        Assembly? resultAssembly;
        var sb = new StringBuilder();
        var report = new TestExecutionReport();
        // Проверка наличия ошибок компиляции
        using (var ms = new MemoryStream())
        {
            var result = compilation.Emit(ms);
            if (!result.Success)
            {
                sb.AppendLine("🤡Не удалось скомпилировать:");
                foreach (var diagnostic in result.Diagnostics.Where(diagnostic 
                             => diagnostic.Severity == DiagnosticSeverity.Error)) //отлов только ошибок не предупреждений
                {
                    sb.AppendLine(diagnostic.GetMessage());
                }
                report.Output = sb.ToString();
                report.UseRawOutput = true;
                return report;
            }
            ms.Seek(0, SeekOrigin.Begin);
            resultAssembly = Assembly.Load(ms.ToArray());
        }

        foreach (Type type in resultAssembly.GetTypes())
        {
            if (!Attribute.IsDefined(type, typeof(NUnit.Framework.TestFixtureAttribute))) continue;
            var finalException = "";
            foreach (MethodInfo method in type.GetMethods())
            {
                if (!Attribute.IsDefined(method, typeof(NUnit.Framework.TestAttribute))) continue;
                
                report.TestsTotalCount++;
                var instance = Activator.CreateInstance(type);
                try
                {
                    method.Invoke(instance, null);
                    sb.AppendLine($"{method.Name}: ✅Пройден");
                    report.TestsPassed++;
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"{method.Name}: 🤡Завален");
                    finalException = ex.InnerException.Message;
                }
            }

            if (report.TestsTotalCount != report.TestsPassed)
            {
                sb.AppendLine("\nОшибки:");
                sb.AppendLine(finalException);
            }
        }
        report.Output = sb.ToString()
            .Replace("\r\n\r\n\r\n", ""); // почему эти символы появляются????
        return report;
    }

}