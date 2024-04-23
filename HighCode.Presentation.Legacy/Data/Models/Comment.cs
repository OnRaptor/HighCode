using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Data.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        public int? RelatedTaskSolutionId { get; set; }
        public CodeTaskSolution? RelatedTaskSolution { get; set; }
        public int? RelatedTaskId { get; set; }
        public CodeTask? RelatedTask { get; set; }
        public int? RepliedCommentId { get; set; }
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
