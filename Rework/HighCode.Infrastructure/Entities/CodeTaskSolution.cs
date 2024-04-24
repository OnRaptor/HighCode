#region

using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace HighCode.Infrastructure.Entities;

public class CodeTaskSolution
{
    public Guid Id { get; set; }
    public Guid RelatedTaskId { get; set; }
    public CodeTask RelatedTask { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public string Code { get; set; }
    public List<Comment> Comments { get; set; }

    [NotMapped] public int InterestingReactionCount { get; set; }

    [NotMapped] public int CleverReactionCount { get; set; }

    [NotMapped] public int FunReactionCount { get; set; }

    public bool IsTested { get; set; }
    public bool IsPublished { get; set; }
}