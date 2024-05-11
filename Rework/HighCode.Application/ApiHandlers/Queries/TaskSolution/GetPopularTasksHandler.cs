using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Domain.ApiRequests.Tasks;
using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.TaskSolution;

public class GetPopularTasksHandler(
    TaskRepository taskRepository,
    IMapper mapper,
    ResponseFactory<GetPopularTasksResponse> responseFactory)
    : IRequestHandler<GetPopularTasksQuery, Result<GetPopularTasksResponse>>
{
    public async Task<Result<GetPopularTasksResponse>> Handle(GetPopularTasksQuery request,
        CancellationToken cancellationToken)
    {
        return responseFactory.SuccessResponse(new GetPopularTasksResponse
        {
            Tasks = taskRepository.GetPopularTasks().Select(ti =>
                new GetPopularTasksResponse.PopularTaskItem(mapper.Map<TaskDTO>(ti.task), ti.count))
        });
    }
}