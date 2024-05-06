#region

using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Tasks;

public class GetTaskByIdQuery : IRequest<Result<GetTaskByIdResponse>>
{
    public Guid Id { get; set; }
}