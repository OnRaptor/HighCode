#region

using HighCode.Application.Responses;
using HighCode.Domain.DTO;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.CodeTask.CreateTask;

public class CreateTaskCommand : IRequest<Result<SimpleResponse>>
{
    public TaskDTO Task { get; set; }
    public Guid UserId { get; set; }
}