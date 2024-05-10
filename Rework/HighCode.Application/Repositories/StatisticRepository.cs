using HighCode.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Application.Repositories;

public class StatisticRepository(AppDbContext _context)
{
    public async Task<int> GetCompletedTasksCountForUser(Guid userId)
    {
        return await _context.CodeTaskSolutions
            .Include(x => x.Author)
            .Where(x => x.AuthorId == userId && x.IsTested)
            .CountAsync();
    }

    public async Task<int?> GetRatingPositionForUser(Guid userId)
    {
        return (await _context.Leaderboard
                .Include(x => x.User)
                .OrderByDescending(l => l.Score)
                .ToListAsync())
            .Select((l, i) => new { l, i })
            .FirstOrDefault(x => x.l.UserId == userId)?.i ?? null;
    }

    public async Task<double?> GetScoreForUser(Guid userId)
    {
        return (await _context.Leaderboard
            .Include(x => x.User)
            .FirstOrDefaultAsync(l => l.UserId == userId))?.Score ?? null;
    }
}