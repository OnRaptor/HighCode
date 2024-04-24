namespace HighCode.Domain.DTO;

public class SolutionDTO
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public bool IsPublished { get; set; }
    public bool IsTested { get; set; }
}