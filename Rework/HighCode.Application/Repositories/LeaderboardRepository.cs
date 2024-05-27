using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Application.Repositories;

public class LeaderboardRepository(AppDbContext _context)
{
    public async Task<IEnumerable<Leaderboard>> GetLeaderboard()
    {
        return await _context.Leaderboard
            .AsNoTracking()
            .Include(x => x.User)
            .OrderByDescending(x => x.Score)
            .ToListAsync();
    }

    public async Task<Leaderboard?> GetLeaderboardByUserId(Guid userId) =>
        await _context.Leaderboard.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
    
    public async Task<bool> AddLeaderboard(Leaderboard leaderboard)
    {
        await _context.Leaderboard.AddAsync(leaderboard);
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

    public async Task<bool> UpdateLeaderboard(Leaderboard leaderboard)
    {
        _context.Leaderboard.Update(leaderboard);
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
}