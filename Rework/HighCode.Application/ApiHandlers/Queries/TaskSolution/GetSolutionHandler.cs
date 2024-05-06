#region

using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Solutions;
using HighCode.Domain.ApiResponses.Solutions;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Queries.TaskSolution;

public class GetSolutionHandler(
    ResponseFactory<GetSolutionResponse> responseFactory,
    SolutionRepository repository,
    CorrelationContext correlationContext,
    TaskRepository taskRepository,
    IMapper mapper
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
                Solution = mapper.Map<SolutionDTO>(solution)
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