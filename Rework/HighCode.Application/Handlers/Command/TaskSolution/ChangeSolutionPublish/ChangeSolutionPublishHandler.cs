#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Command.TaskSolution.ChangeSolutionPublish;

public class ChangeSolutionPublishHandler(
    ResponseFactory<SimpleResponse> responseFactory,
    SolutionRepository repository,
    CorrelationContext correlationContext
)
    : IRequestHandler<ChangeSolutionPublishCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(ChangeSolutionPublishCommand request,
        CancellationToken cancellationToken)
    {
        var userId = correlationContext.GetUserId();
        if (!userId.HasValue) responseFactory.BadRequestResponse("Нет доступа");
        var existingSolution = await repository.GetSolutionByTaskForUser(request.TaskId, userId.Value);
        if (existingSolution == null) return responseFactory.BadRequestResponse("Решение не найдено");

        existingSolution.IsPublished = request.IsPublish;
        await repository.UpdateSolution(existingSolution);
        return responseFactory.SuccessResponse(new SimpleResponse { Message = "Статус публикации решения изменен" });
    }
}