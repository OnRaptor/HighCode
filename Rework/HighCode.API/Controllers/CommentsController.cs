using HighCode.Application.Handlers.Command.Comments.PostComment;
using HighCode.Application.Handlers.Command.TaskSolution.SaveSolution;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

[Route("api/comments/[action]")]
public class CommentsController(IMediator _mediator, ILogger<CommentsController> logger)
    : BaseApiController<CommentsController>(_mediator, logger)
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostComment(
        [FromBody] PostCommentCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetComments(
        [FromQuery] GetCommentsQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> DeleteComment(
        [FromQuery] DeleteCommentCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}