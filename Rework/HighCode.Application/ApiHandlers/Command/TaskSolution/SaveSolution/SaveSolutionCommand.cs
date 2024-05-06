#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.TaskSolution.SaveSolution;

public class SaveSolutionCommand : IRequest<Result<SimpleResponse>>
{
    public string Code { get; set; }
    public Guid TaskId { get; set; }
}