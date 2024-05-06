using HighCode.Domain.Models;

namespace HighCode.Infrastructure.Entities;


public class CodeTaskSolutionReactions
{
    public Guid Id { get; set; }
    public Guid SolutionId { get; set; }
    public CodeTaskSolution Solution { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public SolutionReactionType Reaction { get; set; }
}