using HighCode.Application.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.Leaderboard;

public class GetLeaderboardsQuery : IRequest<Result<GetLeaderboardsResponse>>
{

}