#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.CodeTask.DeleteTask;

public class DeleteTaskHandler(
    ResponseFactory<SimpleResponse> responseFactory,
    TaskRepository repository
) : IRequestHandler<DeleteTaskCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        if (await repository.DeleteTask(request.TaskId))
            return responseFactory.SuccessResponse(new SimpleResponse { Message = "Задача удалена" });
        return responseFactory.BadRequestResponse("Не удалось удалить задачу");
    }
}