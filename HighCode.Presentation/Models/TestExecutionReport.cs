namespace HighCode.Presentation.Models;

public class TestExecutionReport
{
    public int TestsPassed { get; set; }
    public int TestsTotalCount { get; set; }
    public string Output { get; set; }
    public bool UseRawOutput { get; set; }
}