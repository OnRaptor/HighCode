namespace HighCode.Presentation.Data.Models;

public enum SolutionReactionType
{
    Interesting,
    Clever,
    Fun
}

public class CodeTaskSolutionReactions
{
    public int Id { get; set; }
    public CodeTaskSolution Solution { get; set; }
    public User Author { get; set; }
    public SolutionReactionType Reaction { get; set; }
}