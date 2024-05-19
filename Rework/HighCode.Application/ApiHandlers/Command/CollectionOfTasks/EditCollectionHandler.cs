using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.CollectionOfTasks;

public class EditCollectionHandler(
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<EditCollectionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(EditCollectionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}