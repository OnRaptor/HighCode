#region

using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Tasks;

public class EditTaskCommand : IRequest<Result<SimpleResponse>>
{
    public Guid TaskId { get; set; }
    public TaskDTO Task { get; set; }
}