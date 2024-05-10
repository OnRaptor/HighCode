using HighCode.Domain.ApiResponses.Solutions;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Solutions;

public class GetSolutionsQuery : IRequest<Result<GetSolutionsResponse>>
{
    public Guid TaskId { get; set; }
}