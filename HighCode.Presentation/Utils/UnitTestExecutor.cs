//namespace HighCode.Presentation.Utils;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

public class UnitTestExecutor
{
    public async static Task<string> Execute(string code)
    {
        var options = ScriptOptions.Default.AddReferences("NUnit");
        var script = CSharpScript.Create(code, options);
        ScriptState state;
        try
        { 
            state = await script.RunAsync();
        }
        catch (CompilationErrorException e)
        {
            return e.Message;
        }

        if (state.Exception != null)
            return state.Exception.Message;

        return state.ReturnValue as string;
    }

}