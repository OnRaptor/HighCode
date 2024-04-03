using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Data.Models
{
    public class CodeTaskSolution
    {
        public int Id { get; set; }
        public int RelatedTaskId { get; set; }
        public CodeTask RelatedTask { get; set; }
        public string AuthorId { get; set; }
        public IdentityUser Author { get; set; }
        public string Code { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public int VotesUp {  get; set; }
        public int VotesDown {  get; set; }
        public bool IsTested { get; set; }
        public bool IsPublished { get; set; }
    }
}
