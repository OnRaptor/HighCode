using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Application.Repositories;

public class TaskCollectionRepository(AppDbContext _context)
{
    public async Task<bool> Create(CollectionOfTasks collection)
    {
        _context.CollectionOfTasks.Add(collection);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(CollectionOfTasks collection)
    {
        _context.CollectionOfTasks.Update(collection);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }

    public async Task<IEnumerable<CollectionOfTasks>> GetAll()
    {
        return await _context.CollectionOfTasks
            .Include(x => x.Author)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CollectionOfTasks?> GetById(Guid id)
    {
        return await _context.CollectionOfTasks
            .Include(x => x.Author)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<CodeTask>> GetTasksInCollection(Guid collectionId)
    {
        var collection = await _context.CollectionOfTasks
            .Include(x => x.Tasks)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == collectionId);
        return collection?.Tasks ?? new List<CodeTask>();
    }

    public async Task<bool> AddTaskToCollection(Guid collectionId, Guid taskId)
    {
        var collection = await _context.CollectionOfTasks
            .Include(x => x.Tasks)
            .FirstOrDefaultAsync(c => c.Id == collectionId);
        if (collection == null) return false;
        var relatedTask = await _context.CodeTasks.FirstOrDefaultAsync(x => x.Id == taskId);
        if (relatedTask == null) return false;
        collection.Tasks.Add(relatedTask);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }

    public async Task<bool> RemoveTaskFromCollection(Guid collectionId, Guid taskId)
    {
        var collection = await _context.CollectionOfTasks
            .Include(x => x.Tasks)
            .FirstOrDefaultAsync(c => c.Id == collectionId);
        if (collection?.Tasks == null || !collection.Tasks.Any()) return false;
        var relatedTask = collection.Tasks.FirstOrDefault(x => x.Id == taskId);
        if (relatedTask == null) return false;
        collection.Tasks.Remove(relatedTask);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }
}