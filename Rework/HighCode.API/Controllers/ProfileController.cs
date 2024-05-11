using HighCode.Domain.ApiRequests.UserProfile;
using HighCode.Domain.ApiResponses.UserProfile;
using HighCode.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

[Route("api/profile/[action]")]
public class ProfileController(IMediator _mediator, ILogger<LeaderboardController> logger)
    : BaseApiController<LeaderboardController>(_mediator, logger)
{
    [HttpGet]
    [Authorize]
    [ProducesResponseType<GetUserProfileResponse>(200)] 
    public async Task<IActionResult> GetUserProfile(
        CancellationToken cancellationToken)
    {
        return await RequestAsync(new GetUserProfileQuery(), cancellationToken);
    }

    [HttpPost]
    [Authorize("AllAuthNotBanned")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> EditProfile(
        [FromBody] EditUserProfileCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}