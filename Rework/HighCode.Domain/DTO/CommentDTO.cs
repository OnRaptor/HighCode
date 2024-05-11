namespace HighCode.Domain.DTO;

public class CommentDTO
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string AuthorName { get; set; }
    public Guid AuthorId { get; set; }
    public string? AnotherAuthor { get; set; }
    public DateTime DateCreated { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public int? MyReaction { get; set; }
    public List<CommentDTO>? Replies { get; set; }
    public int RepliesCount { get; set; }
    public bool IsMine { get; set; }
}