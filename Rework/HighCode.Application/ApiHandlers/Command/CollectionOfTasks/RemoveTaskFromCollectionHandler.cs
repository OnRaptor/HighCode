using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.CollectionOfTasks;

public class RemoveTaskFromCollectionHandler(
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<RemoveTaskFromCollectionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(RemoveTaskFromCollectionCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}