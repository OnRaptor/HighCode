using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Data.Models
{
    public class CodeTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UnitTestCode { get; set; }
        public string TemplateFuncSignature { get; set; }
        public int Complexity {  get; set; }
        public string ProgrammingLanguage { get; set; }
        public User? Author { get; set; }

        public static string ComplexityToString(int complexity)
        {
            switch (complexity)
            {
                case 0:
                    return "Легко";
                case 1:
                    return "Средне";
                case 2:
                    return "Сложно";
                default:
                    return "";
            }
        }
    }
}
