#region

using HighCode.Application.Handlers.Command.Login;
using HighCode.Application.Handlers.Command.Register;
using HighCode.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace HighCode.API.Controllers;

[Route("api/user/[action]")]
public class UserController(IMediator _mediator, ILogger<UserController> logger)
    : BaseApiController<UserController>(_mediator, logger)
{
    [HttpPost]
    public async Task<IActionResult> Login(
        [FromBody] LoginCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] RegisterCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}