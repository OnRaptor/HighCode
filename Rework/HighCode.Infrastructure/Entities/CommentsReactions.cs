using HighCode.Domain.Models;

namespace HighCode.Infrastructure.Entities;

public class CommentsReactions
{
    public Guid Id { get; set; }
    public Guid CommentId { get; set; }
    public Comment Comment { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public CommentReactionType Reaction { get; set; }
}