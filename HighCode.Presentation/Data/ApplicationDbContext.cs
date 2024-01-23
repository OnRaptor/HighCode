using HighCode.Presentation.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<CodeTask> CodeTasks { get; set; }
        public DbSet<CodeTaskSolution> CodeTaskSolutions { get; set; }
        public DbSet<CollectionOfTasks> CollectionOfTasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
