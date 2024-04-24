#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Command.TaskSolution.ChangeSolutionPublish;

public class ChangeSolutionPublishCommand : IRequest<Result<SimpleResponse>>
{
    public Guid TaskId { get; set; }
    public bool IsPublish { get; set; }
}