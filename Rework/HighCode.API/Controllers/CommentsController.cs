using HighCode.Domain.ApiRequests.Comments;
using HighCode.Domain.ApiResponses.Comments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

[Route("api/comments/[action]")]

public class CommentsController(IMediator _mediator, ILogger<CommentsController> logger)
    : BaseApiController<CommentsController>(_mediator, logger)
{
    [HttpPost]
    [Authorize("AllAuthNotBanned")]
    [ProducesResponseType<PostCommentResponse>(200)]
    public async Task<IActionResult> PostComment(
        [FromBody] PostCommentCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpGet]
    [ProducesResponseType<GetCommentsResponse>(200)]
    public async Task<IActionResult> GetComments(
        [FromQuery] GetCommentsQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
    
    [HttpPost]
    [Authorize("AllAuthNotBanned")]
    [ProducesResponseType<DeleteCommentResponse>(200)]
    public async Task<IActionResult> DeleteComment(
        [FromQuery] DeleteCommentCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}