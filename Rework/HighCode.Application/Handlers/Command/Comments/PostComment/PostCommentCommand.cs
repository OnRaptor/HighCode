using HighCode.Application.Responses;
using MediatR;

namespace HighCode.Application.Handlers.Command.Comments.PostComment;

public class PostCommentCommand : IRequest<Result<PostCommentResponse>>
{
    public string Content { get; set; }
    public string? AnotherAuthorName { get; set; }
    public Guid? RelatedCommentId { get; set; }
    public Guid? RelatedSolutionId { get; set; }
    public Guid? RelatedTaskId { get; set; }
}