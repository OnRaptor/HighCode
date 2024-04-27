using HighCode.Application.Responses;
using MediatR;

namespace HighCode.Application.Handlers.Queries.Leaderboard;

public class GetLeaderboardsQuery : IRequest<Result<GetLeaderboardsResponse>>
{

}