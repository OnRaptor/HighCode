#region

using HighCode.Application.Handlers.Command.TaskSolution.ChangeSolutionPublish;
using HighCode.Application.Handlers.Command.TaskSolution.SaveSolution;
using HighCode.Application.Handlers.Command.TaskSolution.TestCode;
using HighCode.Application.Handlers.Queries.TaskSolution.GetSolutionForUser;
using HighCode.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace HighCode.API.Controllers;

[Route("api/solution/[action]")]
public class SolutionController(
    IMediator _mediator,
    ILogger<SolutionController> logger,
    CorrelationContext _correlationContext)
    : BaseApiController<SolutionController>(_mediator, logger, _correlationContext)
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SaveSolution(
        [FromBody] SaveSolutionCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ChangeSolutionPublish(
        [FromBody] ChangeSolutionPublishCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetSolutionForUser(
        [FromQuery] GetSolutionQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> TestCode(
        [FromBody] TestCodeCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}