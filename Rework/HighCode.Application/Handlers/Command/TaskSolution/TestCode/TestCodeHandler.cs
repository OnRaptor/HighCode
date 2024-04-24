#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Command.TaskSolution.TestCode;

public class TestCodeHandler(
    ResponseFactory<SimpleResponse> responseFactory,
    SolutionRepository repository,
    TaskRepository taskRepository,
    CorrelationContext correlationContext
) : IRequestHandler<TestCodeCommand, Result<TestCodeResponse>>
{
    public Task<Result<TestCodeResponse>> Handle(TestCodeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}