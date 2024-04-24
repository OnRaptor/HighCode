namespace HighCode.Domain.DTO;

public class TaskDTO
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? UnitTestCode { get; set; }
    public string? TemplateFuncSignature { get; set; }
    public int? Complexity { get; set; }
    public string? ProgrammingLanguage { get; set; }
}