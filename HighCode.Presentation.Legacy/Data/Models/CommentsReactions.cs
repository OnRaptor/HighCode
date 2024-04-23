namespace HighCode.Presentation.Data.Models;

public enum ReactionType
{
    Like,
    Dislike
}

public class CommentsReactions
{
    public int Id { get; set; }
    public Comment Comment { get; set; }
    public User Author { get; set; }
    public ReactionType Reaction { get; set; }
}