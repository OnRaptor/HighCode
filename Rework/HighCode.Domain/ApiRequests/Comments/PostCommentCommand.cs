using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Comments;

public class PostCommentCommand : IRequest<Result<PostCommentResponse>>
{
    public string Content { get; set; }
    public string? AnotherAuthorName { get; set; }
    public int TargetType { get; set; }
    public Guid? RelatedTargetId { get; set; }
}