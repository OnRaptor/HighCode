using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Comments;

public class GetCommentsQuery : IRequest<Result<GetCommentsResponse>>
{
    public int TargetTypeForComment { get; set; }
    public Guid? RelatedTargetId { get; set; }
}