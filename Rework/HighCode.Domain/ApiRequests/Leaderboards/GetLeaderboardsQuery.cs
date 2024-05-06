using HighCode.Domain.ApiResponses.Leaderboards;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Leaderboards;

public class GetLeaderboardsQuery : IRequest<Result<GetLeaderboardsResponse>>
{

}