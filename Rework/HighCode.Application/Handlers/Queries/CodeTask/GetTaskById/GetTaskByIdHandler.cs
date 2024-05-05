#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Runners;
using HighCode.Domain.DTO;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Queries.CodeTask.GetTaskById;

public class GetTaskByIdHandler(
    ResponseFactory<GetTaskByIdResponse> responseFactory,
    TaskRepository repository,
    RunnerFactory runnerFactory
) : IRequestHandler<GetTaskByIdQuery, Result<GetTaskByIdResponse>>
{
    public async Task<Result<GetTaskByIdResponse>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetById(request.Id);
        if (result == null)
            return responseFactory.BadRequestResponse("Не удалось найти задачу");

        var task = new TaskDTO()
        {
            Title = result.Title,
            Description = result.Description,
            UnitTestCode = result.UnitTestCode,
            Complexity = result.Complexity,
            ProgrammingLanguage = result.ProgrammingLanguage,
            CodeTemplate = result.CodeTemplate,
            Category = result.Category,
            Id = result.Id,
            IsPublished = result.IsPublished ? true : null
        };
        return responseFactory.SuccessResponse(new GetTaskByIdResponse
        {
            Task = task,
            IsTestingAvailable = runnerFactory.GetRunnerByLanguage(task.ProgrammingLanguage) != null
        });
    }
}