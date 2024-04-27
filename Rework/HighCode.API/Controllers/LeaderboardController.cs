using HighCode.Application.Handlers.Queries.Leaderboard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

[Route("api/leaderboard/[action]")]
public class LeaderboardController(IMediator _mediator, ILogger<LeaderboardController> logger)
    : BaseApiController<LeaderboardController>(_mediator, logger)
{
    [HttpGet]
    public async Task<IActionResult> GetLeaderboard(
        CancellationToken cancellationToken)
    {
        return await RequestAsync(new GetLeaderboardsQuery(), cancellationToken);
    }
}