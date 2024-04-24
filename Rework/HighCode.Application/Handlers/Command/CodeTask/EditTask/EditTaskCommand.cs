#region

using HighCode.Application.Responses;
using HighCode.Domain.DTO;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Command.CodeTask.EditTask;

public class EditTaskCommand : IRequest<Result<SimpleResponse>>
{
    public Guid TaskId { get; set; }
    public TaskDTO Task { get; set; }
}