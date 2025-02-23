﻿#region

using HighCode.Domain.ApiRequests.Solutions;
using HighCode.Domain.ApiResponses.Solutions;
using HighCode.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace HighCode.API.Controllers;

[Route("api/solution/[action]")]
public class SolutionController(
    IMediator _mediator,
    ILogger<SolutionController> logger)
    : BaseApiController<SolutionController>(_mediator, logger)
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> SaveSolution(
        [FromBody] SaveSolutionCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize(Policy = "AllAuthNotBanned")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> ChangeSolutionPublish(
        [FromBody] ChangeSolutionPublishCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType<GetSolutionResponse>(200)]
    public async Task<IActionResult> GetSolutionForUser(
        [FromQuery] GetSolutionQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpGet]
    [ProducesResponseType<GetSolutionsResponse>(200)]
    public async Task<IActionResult> GetSolutions(
        [FromQuery] GetSolutionsQuery query,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(query, cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType<TestCodeResponse>(200)]
    public async Task<IActionResult> TestCode(
        [FromBody] TestCodeCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}