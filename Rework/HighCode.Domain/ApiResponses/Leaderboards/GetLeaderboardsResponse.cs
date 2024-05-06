using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.Leaderboards;

public class GetLeaderboardsResponse : ResponseBase
{
    public IEnumerable<LeaderboardDTO> Leaderboards { get; set; }
}