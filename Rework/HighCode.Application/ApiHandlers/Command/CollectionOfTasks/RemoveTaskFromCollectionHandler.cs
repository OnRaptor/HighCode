using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.CollectionOfTasks;

public class RemoveTaskFromCollectionHandler(
    TaskCollectionRepository taskCollectionRepository,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<RemoveTaskFromCollectionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(RemoveTaskFromCollectionCommand request,
        CancellationToken cancellationToken)
    {
        if (!await taskCollectionRepository.RemoveTaskFromCollection(request.CollectionId, request.TaskId))
            return responseFactory.ConflictResponse("Не удалось удалить задачу из коллекции");

        return responseFactory.SuccessResponse(new SimpleResponse { Message = "Задача удалена из коллекции" });
    }
}