using HighCode.Application.ApiHandlers.Queries.Leaderboard;
using HighCode.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

[Route("api/leaderboard/[action]")]
public class LeaderboardController(IMediator _mediator, ILogger<LeaderboardController> logger)
    : BaseApiController<LeaderboardController>(_mediator, logger)
{
    [HttpGet]
    [ProducesResponseType<GetLeaderboardsResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> GetLeaderboard(
        CancellationToken cancellationToken)
    {
        return await RequestAsync(new GetLeaderboardsQuery(), cancellationToken);
    }
}