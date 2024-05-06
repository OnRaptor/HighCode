using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.Leaderboards;
using HighCode.Domain.ApiResponses.Leaderboards;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.Leaderboard;

public class GetLeaderboardsHandler(
    LeaderboardRepository repository,
    ResponseFactory<GetLeaderboardsResponse> responseFactory)
    : IRequestHandler<GetLeaderboardsQuery, Result<GetLeaderboardsResponse>>
{
    public async Task<Result<GetLeaderboardsResponse>> Handle(GetLeaderboardsQuery request, CancellationToken cancellationToken)
    {
        var leaderboards = await repository.GetLeaderboard();
        return responseFactory.SuccessResponse(new()
        {
            Leaderboards = leaderboards.Select(l => new LeaderboardDTO()
            {
                Score = l.Score,
                Username = l.User.UserName
            })
        });
    }
}