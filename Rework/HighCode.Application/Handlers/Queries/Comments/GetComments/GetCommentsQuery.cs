using HighCode.Application.Handlers.Queries.Comments.GetComments;
using HighCode.Application.Responses;
using MediatR;

public class GetCommentsQuery : IRequest<Result<GetCommentsResponse>>
{
    public Guid? RelatedCommentId { get; set; }
    public Guid? RelatedSolutionId { get; set; }
    public Guid? RelatedTaskId { get; set; }
}