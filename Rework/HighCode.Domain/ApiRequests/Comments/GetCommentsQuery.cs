using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Comments;

public class GetCommentsQuery : IRequest<Result<GetCommentsResponse>>
{
    public Guid? RelatedCommentId { get; set; }
    public Guid? RelatedSolutionId { get; set; }
    public Guid? RelatedTaskId { get; set; }
}