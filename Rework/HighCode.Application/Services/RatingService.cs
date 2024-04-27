using HighCode.Application.Repositories;
using HighCode.Application.Runners.Models;
using HighCode.Infrastructure.Entities;

namespace HighCode.Application.Services;

public class RatingService(LeaderboardRepository leaderboardRepository)
{
    public async Task ApplyScoreFromCompletedTask(Guid userId, TestCodeResult report, CodeTask task)
    {
        if (report.TotalTestsCount == 0 || report.SuccessTestCount != report.TotalTestsCount) return;
        
        var score = (5 + report.TotalTestsCount * 0.5) * (task.Complexity == 0?1 : task.Complexity);
        
        var existingLb = await leaderboardRepository.GetLeaderboardByUserId(userId);

        if (existingLb == null)
        {
            var lb = new Leaderboard
            {
                Score = score,
                UserId = userId
            };
            await leaderboardRepository.AddLeaderboard(lb);
            return;
        }
        existingLb.Score += score;
        await leaderboardRepository.UpdateLeaderboard(existingLb);
    }
}