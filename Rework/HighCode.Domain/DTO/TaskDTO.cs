namespace HighCode.Domain.DTO;

public class TaskDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string UnitTestCode { get; set; }
    public string CodeTemplate { get; set; }
    public int? Complexity { get; set; }
    public string ProgrammingLanguage { get; set; }
    public bool IsPublished { get; set; }
    public bool IsSuggested { get; set; }
    public string? AuthorName { get; set; }
    public string? Category { get; set; }

    public static string ComplexityToString(int complexity)
    {
        return complexity switch
        {
            0 => "Легко",
            1 => "Средне",
            2 => "Сложно",
            _ => ""
        };
    }
}