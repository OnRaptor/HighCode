#region

using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

#endregion

namespace HighCode.Application.Repositories;

public class SolutionRepository
{
    private readonly AppDbContext _context;

    public SolutionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateSolution(CodeTaskSolution solution)
    {
        await _context.CodeTaskSolutions.AddAsync(solution);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateSolution(CodeTaskSolution solution)
    {
        _context.CodeTaskSolutions.Update(solution);
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

    public async Task<CodeTaskSolution?> GetSolutionById(Guid id)
    {
        return await _context.CodeTaskSolutions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CodeTaskSolution?> GetSolutionByTaskForUser(Guid codeTask, Guid userId)
    {
        return await _context.CodeTaskSolutions.AsNoTracking()
            .Where(x => x.AuthorId == userId && x.RelatedTaskId == codeTask)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CodeTaskSolution>> GetSolutions()
    {
        return await _context.CodeTaskSolutions.AsNoTracking()
            .Include(x => x.Author)
            .Include(x => x.RelatedTask)
            .Where(x => x.IsPublished)
            .ToListAsync();
    }

    public async Task<bool> DeleteSolution(Guid id)
    {
        return await _context.CodeTaskSolutions.Where(x => x.Id == id).ExecuteDeleteAsync() == 1;
    }
}