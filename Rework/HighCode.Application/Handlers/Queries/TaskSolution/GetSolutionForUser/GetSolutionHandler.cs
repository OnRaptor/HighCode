#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Runners;
using HighCode.Application.Services;
using HighCode.Domain.DTO;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Queries.TaskSolution.GetSolutionForUser;

public class GetSolutionHandler(
    ResponseFactory<GetSolutionResponse> responseFactory,
    SolutionRepository repository,
    CorrelationContext correlationContext,
    TaskRepository  taskRepository
) : IRequestHandler<GetSolutionQuery, Result<GetSolutionResponse>>
{
    public async Task<Result<GetSolutionResponse>> Handle(GetSolutionQuery request, CancellationToken cancellationToken)
    {
        var userId = correlationContext.GetUserId();
        if (userId == null) responseFactory.BadRequestResponse("Нет доступа");
        var solution = await repository.GetSolutionByTaskForUser(request.TaskId, userId.Value);
        var task = await taskRepository.GetById(request.TaskId);
        if (solution != null)
            return responseFactory.SuccessResponse(new GetSolutionResponse()
            {
                Solution = new SolutionDTO()
                {
                    Code = solution.Code,
                    IsPublished = solution.IsPublished,
                    IsTested = solution.IsTested,
                    Id = solution.Id
                }
            });
        return responseFactory.SuccessResponse(new GetSolutionResponse()
        {
            Solution = new SolutionDTO()
            {
                Id=null,
                Code = task.CodeTemplate
            }
        });
    }
}