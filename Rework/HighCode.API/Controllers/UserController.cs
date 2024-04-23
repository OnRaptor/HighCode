using HighCode.Application.Handlers.Command.Login;
using HighCode.Application.Handlers.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

[ApiController]
[Route("api/user/[action]")]
[Produces("application/json")]
public class UserController : BaseApiController<UserController>
{
    public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator, logger)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Login(
        [FromBody]LoginCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody]RegisterCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}