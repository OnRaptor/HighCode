using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<CodeTask> CodeTasks { get; set; }
    public DbSet<CodeTaskSolution> CodeTaskSolutions { get; set; }
    public DbSet<CollectionOfTasks> CollectionOfTasks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CommentsReactions> CommentsReactions { get; set; }
    public DbSet<CodeTaskSolutionReactions> CodeTaskSolutionReactions { get; set; }
    public DbSet<Leaderboard> Leaderboard { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}