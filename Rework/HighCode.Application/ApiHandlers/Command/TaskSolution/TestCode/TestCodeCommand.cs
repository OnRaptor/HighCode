#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.TaskSolution.TestCode;

public class TestCodeCommand : IRequest<Result<TestCodeResponse>>
{
    public string Code { get; set; }
    public Guid TaskId { get; set; }
}