using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Comments;

public class PostCommentCommand : IRequest<Result<PostCommentResponse>>
{
    public string Content { get; set; }
    public string? AnotherAuthorName { get; set; }
    public Guid? RelatedCommentId { get; set; }
    public Guid? RelatedSolutionId { get; set; }
    public Guid? RelatedTaskId { get; set; }
}