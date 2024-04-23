namespace HighCode.Infrastructure.Entities
{
    public class CodeTask
    {
        public Guid Id { get; set; }
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
                case 1:
                    return "Легко";
                case 2:
                    return "Средне";
                case 3:
                    return "Сложно";
                default:
                    return "";
            }
        }
    }
}
