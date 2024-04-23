using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Data.Models
{
    public class CodeTaskSolution
    {
        public int Id { get; set; }
        public int RelatedTaskId { get; set; }
        public CodeTask RelatedTask { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string Code { get; set; }
        public List<Comment> Comments { get; set; }
        [NotMapped]
        public int InterestingReactionCount {  get; set; }
        [NotMapped]
        public int CleverReactionCount {  get; set; }
        [NotMapped]
        public int FunReactionCount {  get; set; }
        public bool IsTested { get; set; }
        public bool IsPublished { get; set; }
    }
}
