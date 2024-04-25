using System.Reflection;

namespace HighCode.Application.Runners.Models;

public class CompileResult
{
    public Assembly? CompiledAssembly{ get; set; }
    public string? ErrorOutput { get; set; }
 
    public bool Success { get; set; }
}