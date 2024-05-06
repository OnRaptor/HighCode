using HighCode.Application.ApiHandlers.Command.Reactions.PostReactionForComment;
using HighCode.Application.ApiHandlers.Command.Reactions.PostReactionForSolution;
using HighCode.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

[Route("api/reactions/[action]")]
public class ReactionController(IMediator _mediator, ILogger<UserController> logger)
    : BaseApiController<UserController>(_mediator, logger)
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType<PostReactionForCommentResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> AddReactionToComment(
        [FromBody] PostReactionForCommentCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpPost]
    [Authorize]
    [ProducesResponseType<PostReactionForSolutionResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> AddReactionToSolution(
        [FromBody] PostReactionForSolutionCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}