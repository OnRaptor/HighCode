#region

using HighCode.Domain.Constants;

#endregion

namespace HighCode.Infrastructure.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public Guid RelatedTargetId { get; set; }
    public TargetTypeForComment TargetType { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }
    public string? AnotherAuthor { get; set; }
    public List<Comment> Replies { get; set; }

    public ICollection<CommentsReactions> Reactions { get; set; }
}