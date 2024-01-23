using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Presentation.Data.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public IEnumerable<CodeTask> SolvedTasks { get; set; }
    }
}
