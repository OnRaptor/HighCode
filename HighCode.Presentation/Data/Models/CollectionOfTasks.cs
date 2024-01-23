using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Data.Models
{
    public class CollectionOfTasks
    {
        public int Id { get; set; }
        public IEnumerable<CodeTask> Tasks { get; set; }
        public string Title { get; set; }
        public int Complexity { get; set; }
        public string Description { get; set; }
        public IdentityUser Author { get; set; }
        public IEnumerable<string> ProgrammingLanguages { get; set; }
    }
}
