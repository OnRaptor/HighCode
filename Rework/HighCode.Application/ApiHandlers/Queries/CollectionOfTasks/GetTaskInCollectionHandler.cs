using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.ApiResponses.CollectionOfTasks;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.CollectionOfTasks;

public class GetTaskInCollectionHandler(
    TaskCollectionRepository taskCollectionRepository,
    IMapper mapper,
    ResponseFactory<GetTaskInCollectionResponse> responseFactory)
    : IRequestHandler<GetTaskInCollectionQuery, Result<GetTaskInCollectionResponse>>
{
    public async Task<Result<GetTaskInCollectionResponse>> Handle(GetTaskInCollectionQuery request,
        CancellationToken cancellationToken)
    {
        var tasks = await taskCollectionRepository.GetTasksInCollection(request.CollectionId);
        return responseFactory.SuccessResponse(new GetTaskInCollectionResponse
        {
            Tasks = tasks.Select(mapper.Map<TaskDTO>)
        });
    }
}