#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.CodeTask.CreateTask;

public class CreateTaskHandler(TaskRepository taskRepository, ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<CreateTaskCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new Infrastructure.Entities.CodeTask
        {
            Title = request.Task.Title,
            Description = request.Task.Description,
            UnitTestCode = request.Task.UnitTestCode,
            Complexity = request.Task.Complexity.Value,
            ProgrammingLanguage = request.Task.ProgrammingLanguage,
            CodeTemplate = request.Task.CodeTemplate,
            AuthorId = request.UserId,
            CreateDate = DateTime.UtcNow,
            Category = request.Task.Category
        };
        if (await taskRepository.CreateTask(task))
            return responseFactory.SuccessResponse(new SimpleResponse { Message = "Задача успешно создана" });
        return responseFactory.BadRequestResponse("Не удалось создать задачу");
    }
}