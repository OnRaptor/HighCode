using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.CollectionOfTasks;

public class AddTasksToCollectionHandler(
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<AddTasksToCollectionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(AddTasksToCollectionCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}