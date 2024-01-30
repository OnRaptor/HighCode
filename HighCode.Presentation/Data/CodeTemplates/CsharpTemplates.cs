namespace HighCode.Presentation.Data.CodeTemplates
{
    public class CsharpTemplates
    {
        public static string CreateTemplate(string FuncName) => 
            string.Format(
@"using System;
class Program {{
    public static {0} {{
    }}
}}
            ", FuncName);
        
    }
}
