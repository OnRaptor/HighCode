#region

using HighCode.Domain.ApiRequests.Auth;
using HighCode.Domain.ApiRequests.UserProfile;
using HighCode.Domain.ApiResponses.Auth;
using HighCode.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace HighCode.API.Controllers;

[Route("api/user/[action]")]
public class UserController(IMediator _mediator, ILogger<UserController> logger)
    : BaseApiController<UserController>(_mediator, logger)
{
    [HttpPost]
    [ProducesResponseType<LoginCommandResponse>(200)]
    public async Task<IActionResult> Login(
        [FromBody] LoginCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType<RegisterCommandResponse>(200)]
    public async Task<IActionResult> Register(
        [FromBody] RegisterCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize("StaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> BanUser(
        [FromBody] BanUserCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}