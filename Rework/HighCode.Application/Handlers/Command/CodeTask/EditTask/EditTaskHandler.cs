#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Command.CodeTask.EditTask;

public class EditTaskHandler(
    ResponseFactory<SimpleResponse> responseFactory,
    TaskRepository repository
) : IRequestHandler<EditTaskCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(EditTaskCommand request, CancellationToken cancellationToken)
    {
        var baseTask = await repository.GetById(request.TaskId);
        if (baseTask == null) return responseFactory.BadRequestResponse("Задача не найдена");
        var task = new Infrastructure.Entities.CodeTask
        {
            Id = baseTask.Id,
            Title = request.Task.Title ?? baseTask.Title,
            Description = request.Task.Description ?? baseTask.Description,
            UnitTestCode = request.Task.UnitTestCode ?? baseTask.UnitTestCode,
            Complexity = request.Task.Complexity.HasValue ? request.Task.Complexity.Value : 0,
            ProgrammingLanguage = request.Task.ProgrammingLanguage ?? baseTask.ProgrammingLanguage,
            CodeTemplate = request.Task.CodeTemplate ?? baseTask.CodeTemplate,
            AuthorId = baseTask.AuthorId,
            IsPublished = request.Task.IsPublished ?? baseTask.IsPublished,
            Category = request.Task.Category ?? baseTask.Category
        };
        if (await repository.EditTask(task))
            return responseFactory.SuccessResponse(new SimpleResponse { Message = "Задача обновлена" });
        return responseFactory.BadRequestResponse("Не удалось обновить задачу");
    }
}