using HighCode.Infrastructure.Entities;

namespace HighCode.Domain.DTO;

public class CommentDTO
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string AuthorName { get; set; }
    public string? RepliedAuthorName { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public ReactionType? MyReaction { get; set; }
}