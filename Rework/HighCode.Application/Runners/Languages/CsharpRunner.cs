using System.Reflection;
using System.Text;
using HighCode.Application.Runners.Models;
using HighCode.Domain.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

namespace HighCode.Application.Runners.Languages;

public class CsharpRunner : IRunner
{
    public string ProgrammingLanguage => "csharp";
    
    public CompileResult Compile(string code)
    {
        // Создание сборки из исходного кода
        code = "using System; using NUnit.Framework; namespace Root {\n" + code + "\n}";
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
        var sb = new StringBuilder();
        var compileResult = new CompileResult();
        // Проверка наличия ошибок компиляции
        using var ms = new MemoryStream();
        var result = compilation.Emit(ms);
        if (!result.Success)
        {
            foreach (var diagnostic in result.Diagnostics.Where(diagnostic 
                         => diagnostic.Severity == DiagnosticSeverity.Error)) //отлов только ошибок не предупреждений
            {
                sb.AppendLine(diagnostic.GetMessage());
            }
            compileResult.ErrorOutput = sb.ToString();
            return compileResult;
        }
        ms.Seek(0, SeekOrigin.Begin);
        compileResult.CompiledAssembly = Assembly.Load(ms.ToArray());
        compileResult.Success = true;
        return compileResult;
    }

    public TestCodeResult TestCode(Assembly assembly)
    {
        var report = new TestCodeResult();
        var sb = new StringBuilder();
        foreach (var type in assembly.GetTypes())
        {
            if (!Attribute.IsDefined(type, typeof(TestFixtureAttribute))) continue;
            var finalException = "";
            foreach (var method in type.GetMethods()
                         .Where(method //берутся методы только с [Test] аттридутом
                             => Attribute.IsDefined(method, typeof(TestAttribute))))
            {
                report.TotalTestsCount++;
                var instance = Activator.CreateInstance(type);
                try
                {
                    method.Invoke(instance, null);
                    sb.AppendLine($"{method.Name}: ✅Пройден");
                    report.SuccessTestCount++;
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"{method.Name}: ❌Завален");
                    finalException = ex.InnerException?.Message;
                }
            }

            if (report.SuccessTestCount != report.TotalTestsCount)
            {
                sb.AppendLine("\nОшибки:");
                sb.AppendLine(finalException);
            }
        }
        report.TestOutput = sb.ToString();
        return report;
    }
}