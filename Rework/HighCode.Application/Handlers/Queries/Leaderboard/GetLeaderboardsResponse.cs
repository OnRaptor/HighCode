using HighCode.Application.Responses;
using HighCode.Domain.DTO;

namespace HighCode.Application.Handlers.Queries.Leaderboard;

public class GetLeaderboardsResponse : ResponseBase
{
    public IEnumerable<LeaderboardDTO> Leaderboards { get; set; }
}