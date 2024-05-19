using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.CollectionOfTasks;

public class CreateCollectionHandler(
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<CreateCollectionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(CreateCollectionCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}