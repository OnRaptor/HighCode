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
    public bool? IsPublished { get; set; } = false;

    public string? Category { get; set; }
}