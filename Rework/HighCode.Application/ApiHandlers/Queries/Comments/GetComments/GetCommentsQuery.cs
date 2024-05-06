using HighCode.Application.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.Comments.GetComments;

public class GetCommentsQuery : IRequest<Result<GetCommentsResponse>>
{
    public Guid? RelatedCommentId { get; set; }
    public Guid? RelatedSolutionId { get; set; }
    public Guid? RelatedTaskId { get; set; }
}