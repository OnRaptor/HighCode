using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.ApiResponses.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.CollectionOfTasks;

public class GetTaskInCollectionHandler(
    ResponseFactory<GetTaskInCollectionResponse> responseFactory)
    : IRequestHandler<GetTaskInCollectionQuery, Result<GetTaskInCollectionResponse>>
{
    public async Task<Result<GetTaskInCollectionResponse>> Handle(GetTaskInCollectionQuery request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}