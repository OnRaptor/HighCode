using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Data.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        public CodeTaskSolution RelatedTask { get; set; }
        public IdentityUser Author {  get; set; }
        public string Content { get; set; }
    }
}
