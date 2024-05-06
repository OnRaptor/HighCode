namespace HighCode.Domain.Models;

public class TestCodeResult
{
    public int TotalTestsCount { get; set; }
    public int SuccessTestCount { get; set; } 
    public string? TestOutput { get; set; }
}