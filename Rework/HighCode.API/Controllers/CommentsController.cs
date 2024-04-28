using HighCode.Application.Handlers.Command.Comments.DeleteComment;
using HighCode.Application.Handlers.Command.Comments.PostComment;
using HighCode.Application.Handlers.Command.TaskSolution.SaveSolution;
using HighCode.Application.Handlers.Queries.Comments.GetComments;
using HighCode.Application.Responses;
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
    [ProducesResponseType<PostCommentResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> PostComment(
        [FromBody] PostCommentCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpGet]
    [ProducesResponseType<GetCommentsResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> GetComments(
        [FromQuery] GetCommentsQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpPost]
    [Authorize]
    [ProducesResponseType<DeleteCommentResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteComment(
        [FromQuery] DeleteCommentCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}