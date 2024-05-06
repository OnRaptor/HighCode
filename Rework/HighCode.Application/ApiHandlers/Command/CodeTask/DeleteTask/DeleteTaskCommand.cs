#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.CodeTask.DeleteTask;

public class DeleteTaskCommand : IRequest<Result<SimpleResponse>>
{
    public Guid TaskId { get; set; }
}