namespace HighCode.Infrastructure.Entities;

public class CodeTask
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string UnitTestCode { get; set; }
    public string CodeTemplate { get; set; }
    public int Complexity { get; set; }
    public bool IsPublished { get; set; }
    public bool IsSuggested { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? Category { get; set; }
    public string ProgrammingLanguage { get; set; }
    public Guid? AuthorId { get; set; }
    public User? Author { get; set; }
    public IEnumerable<CollectionOfTasks> CollectionsOfTasks { get; set; }
    
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