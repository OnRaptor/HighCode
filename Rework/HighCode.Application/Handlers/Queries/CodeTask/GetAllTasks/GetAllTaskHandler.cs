#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Queries.CodeTask.GetAllTasks;

public class GetAllTaskHandler(TaskRepository taskRepository, ResponseFactory<GetAllTaskResponse> responseFactory)
    : IRequestHandler<GetAllTaskQuery, Result<GetAllTaskResponse>>
{
    public async Task<Result<GetAllTaskResponse>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
    {
        var tasks = (await taskRepository.GetAllTasks()).ToArray();
        return responseFactory.SuccessResponse(new GetAllTaskResponse
        {
            Tasks = tasks,
            Count = tasks.Length
        });
    }
}