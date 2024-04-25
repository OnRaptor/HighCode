using System.Reflection;
using HighCode.Application.Runners.Models;

namespace HighCode.Application.Runners;

public interface IRunner
{
    public string ProgrammingLanguage { get; }
    public CompileResult Compile(string code);
    public TestCodeResult TestCode(Assembly assembly);
}