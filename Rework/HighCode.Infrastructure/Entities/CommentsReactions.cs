namespace HighCode.Infrastructure.Entities;

public enum ReactionType
{
    Like,
    Dislike
}

public class CommentsReactions
{
    public Guid Id { get; set; }
    public Guid CommentId { get; set; }
    public Comment Comment { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public ReactionType Reaction { get; set; }
}