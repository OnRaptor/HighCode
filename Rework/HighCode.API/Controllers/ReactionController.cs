using HighCode.Application.Handlers.Command.Comments.PostComment;
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
    public async Task<IActionResult> AddReactionToComment(
        [FromBody] PostReactionForCommentCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddReactionToSolution(
        [FromBody] PostReactionForSolutionCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}