#region

using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

#endregion

namespace HighCode.Application.Repositories;

public class TaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateTask(CodeTask task)
    {
        await _context.CodeTasks.AddAsync(task);
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

    public async Task<IEnumerable<CodeTask>> GetAllTasks()
    {
        return await _context.CodeTasks.AsNoTracking().ToListAsync();
    }
    
    public async Task<CodeTask?> GetById(Guid id)
    {
        return await _context.CodeTasks.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteTask(Guid taskId)
    {
        // крайне сомнительный вариант TODO: сделать нормльное удаление
        await _context.Comments
            .Where(x => x.RelatedTaskId == taskId)
            .ExecuteUpdateAsync(setters
                => setters.SetProperty(x => x.RelatedTaskId, null as Guid?));
        return await _context.CodeTasks.Where(x => x.Id == taskId).ExecuteDeleteAsync() == 1;
    }

    public async Task<bool> EditTask(CodeTask task)
    {
        _context.CodeTasks.Update(task);
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