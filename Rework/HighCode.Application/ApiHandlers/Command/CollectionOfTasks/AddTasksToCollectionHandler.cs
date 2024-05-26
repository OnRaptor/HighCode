using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.CollectionOfTasks;

public class AddTasksToCollectionHandler(
    TaskCollectionRepository taskCollectionRepository,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<AddTasksToCollectionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(AddTasksToCollectionCommand request,
        CancellationToken cancellationToken)
    {
        if (!await taskCollectionRepository.AddTaskToCollection(request.CollectionId, request.TaskId))
            return responseFactory.ConflictResponse("Не удалось добавить задачу в коллекцию");

        return responseFactory.SuccessResponse(new SimpleResponse { Message = "Задача добавлена в коллекцию" });
    }
}