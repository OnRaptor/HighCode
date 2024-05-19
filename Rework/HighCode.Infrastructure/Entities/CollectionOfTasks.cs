namespace HighCode.Infrastructure.Entities;

public class CollectionOfTasks
{
    public Guid Id { get; set; }
    public IEnumerable<CodeTask> Tasks { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public bool IsPublished { get; set; }
}