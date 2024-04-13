using HighCode.Presentation.Data;
using HighCode.Presentation.Data.Models;
using HighCode.Presentation.Models;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Presentation.Services;

public class StatisticService
{
    private readonly ApplicationDbContext _context;
    public StatisticService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CalculateScoreForCompletedTask(User user, TestExecutionReport report, CodeTask task)
    {
        if (report.TestsTotalCount == 0 || report.TestsPassed != report.TestsTotalCount) return;
        
        var score = (5 + report.TestsTotalCount * 0.5) * (task.Complexity == 0?1 : task.Complexity);

        var existsRow = await _context.Leaderboard.FirstOrDefaultAsync(l => l.UserId == user.Id);
        if (existsRow == null)
        {
            existsRow = new Leaderboard
            {
                Score = score,
                UserId = user.Id,
            };
            await _context.Leaderboard.AddAsync(existsRow);
        }
        existsRow.Score += score;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Leaderboard>> GetRatings()
    {
        var lds = await _context.Leaderboard
            .Include(x => x.User)
            .OrderByDescending(l => l.Score)
            .ToListAsync();
        return lds;
    }

    public async Task<int> GetCompletedTasksCountForUser(User user)
    {
        return await _context.CodeTaskSolutions
            .Include(x => x.Author)
            .Where(x => x.AuthorId == user.Id && x.IsTested)
            .CountAsync();
    }

    public async Task<int?> GetRatingPositionForUser(User user)
    {
        return (await _context.Leaderboard
            .Include(x => x.User)
            .OrderByDescending(l => l.Score)
            .ToListAsync())
            .Select((l, i) => new { l, i })
            .FirstOrDefault(x => x.l.UserId == user.Id)?.i ?? null;
    }

    public async Task<double?> GetScoreForUser(User user)
    {
        return (await _context.Leaderboard
            .Include(x => x.User)
            .FirstOrDefaultAsync(l => l.UserId == user.Id))?.Score ?? null;
    }
}