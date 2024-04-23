using System.ComponentModel.DataAnnotations.Schema;

namespace HighCode.Infrastructure.Entities
{
    public class Comment
    {
        public Guid Id { get; set; } 
        public Guid? RelatedTaskSolutionId { get; set; }
        public CodeTaskSolution? RelatedTaskSolution { get; set; }
        public Guid? RelatedTaskId { get; set; }
        public CodeTask? RelatedTask { get; set; }
        public Guid? RepliedCommentId { get; set; }
        public Comment? RepliedComment { get; set; }
        public User Author {  get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        [NotMapped]
        public int Likes { get; set; }
        [NotMapped]
        public int Dislikes { get; set; }
        public string? AnotherAuthor { get; set; }
        public List<Comment> Replies { get; set; }
        
        public ICollection<CommentsReactions> Reactions { get; set; }
    }
}
