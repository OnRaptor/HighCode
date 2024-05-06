#region

using HighCode.Domain.ApiResponses.Solutions;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Solutions;

public class GetSolutionQuery : IRequest<Result<GetSolutionResponse>>
{
    public Guid TaskId { get; set; }
}