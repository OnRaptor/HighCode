#region

using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Tasks;

public class CreateTaskCommand : IRequest<Result<SimpleResponse>>
{
    public TaskDTO Task { get; set; }
    public Guid UserId { get; set; }
}