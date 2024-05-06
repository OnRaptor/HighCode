#region

using HighCode.Application.ApiHandlers.Command.Login;
using HighCode.Application.ApiHandlers.Command.Register;
using HighCode.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace HighCode.API.Controllers;

[Route("api/user/[action]")]
public class UserController(IMediator _mediator, ILogger<UserController> logger)
    : BaseApiController<UserController>(_mediator, logger)
{
    [HttpPost]
    [ProducesResponseType<LoginCommandResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Login(
        [FromBody] LoginCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType<RegisterCommandResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register(
        [FromBody] RegisterCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}