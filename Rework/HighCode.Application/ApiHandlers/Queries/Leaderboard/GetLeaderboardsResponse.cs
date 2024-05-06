using HighCode.Application.Responses;
using HighCode.Domain.DTO;

namespace HighCode.Application.ApiHandlers.Queries.Leaderboard;

public class GetLeaderboardsResponse : ResponseBase
{
    public IEnumerable<LeaderboardDTO> Leaderboards { get; set; }
}