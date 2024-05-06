#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Runners;
using HighCode.Application.Services;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.TaskSolution.TestCode;

public class TestCodeHandler(
    ResponseFactory<TestCodeResponse> responseFactory,
    SolutionRepository repository,
    TaskRepository taskRepository,
    CorrelationContext correlationContext,
    RunnerFactory runnerFactory
) : IRequestHandler<TestCodeCommand, Result<TestCodeResponse>>
{
    public async Task<Result<TestCodeResponse>> Handle(TestCodeCommand request, CancellationToken cancellationToken)
    {
        var task = await taskRepository.GetById(request.TaskId);
        var runner = runnerFactory.GetRunnerByLanguage(task.ProgrammingLanguage);
        if (runner == null) 
            return responseFactory.BadRequestResponse("Язык не поддерживается для тестов");
        var compileResult = runner.Compile(request.Code + "\n" + task.UnitTestCode);
        if (!compileResult.Success)
            return responseFactory.ConflictResponse("Не удалось скомпилировать\n" + compileResult.ErrorOutput);

        return responseFactory.SuccessResponse(new()
        {
            TestResult = runner.TestCode(compileResult.CompiledAssembly)
        });
    }
}