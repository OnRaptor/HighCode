#region

using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Application.Runners;
using HighCode.Domain.ApiRequests.Tasks;
using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Queries.CodeTask;

public class GetTaskByIdHandler(
    ResponseFactory<GetTaskByIdResponse> responseFactory,
    TaskRepository repository,
    RunnerFactory runnerFactory,
    IMapper mapper
) : IRequestHandler<GetTaskByIdQuery, Result<GetTaskByIdResponse>>
{
    public async Task<Result<GetTaskByIdResponse>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetById(request.Id);
        if (result == null)
            return responseFactory.BadRequestResponse("Не удалось найти задачу");

        var task = mapper.Map<TaskDTO>(result);
        return responseFactory.SuccessResponse(new GetTaskByIdResponse
        {
            Task = task,
            IsTestingAvailable = runnerFactory.GetRunnerByLanguage(task.ProgrammingLanguage) != null
        });
    }
}