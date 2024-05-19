using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.ApiResponses.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.CollectionOfTasks;

public class GetCollectionsHandler(
    ResponseFactory<GetCollectionsResponse> responseFactory)
    : IRequestHandler<GetCollectionsQuery, Result<GetCollectionsResponse>>
{
    public async Task<Result<GetCollectionsResponse>> Handle(GetCollectionsQuery request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}