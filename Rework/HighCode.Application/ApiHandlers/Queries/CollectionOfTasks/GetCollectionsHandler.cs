using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.ApiResponses.CollectionOfTasks;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.CollectionOfTasks;

public class GetCollectionsHandler(
    TaskCollectionRepository taskCollectionRepository,
    IMapper mapper,
    ResponseFactory<GetCollectionsResponse> responseFactory)
    : IRequestHandler<GetCollectionsQuery, Result<GetCollectionsResponse>>
{
    public async Task<Result<GetCollectionsResponse>> Handle(GetCollectionsQuery request,
        CancellationToken cancellationToken)
    {
        var collections = await taskCollectionRepository.GetAll();
        collections = request.UnPublishedOnly
            ? collections.Where(x => !x.IsPublished).ToList()
            : collections.Where(x => x.IsPublished).ToList();
        return responseFactory.SuccessResponse(new GetCollectionsResponse
        {
            Collections = collections.Select(mapper.Map<CollectionOfTasksDTO>).Reverse()
        });
    }
}