#region

using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Tasks;

public class DeleteTaskCommand : IRequest<Result<SimpleResponse>>
{
    public Guid TaskId { get; set; }
}