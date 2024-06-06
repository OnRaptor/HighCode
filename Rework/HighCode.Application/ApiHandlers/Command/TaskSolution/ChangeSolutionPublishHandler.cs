#region

using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Solutions;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.TaskSolution;

public class ChangeSolutionPublishHandler(
    ResponseFactory<SimpleResponse> responseFactory,
    SolutionRepository repository,
    CorrelationContext correlationContext,
    RatingService ratingService,
    IMediator mediator,
    TaskRepository taskRepository
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
        if (!existingSolution.FirstPublishDate.HasValue && request.IsPublish)
        {
            try
            {
                var testResult = await mediator.Send(new TestCodeCommand
                {
                    TaskId = request.TaskId,
                    Code = existingSolution.Code
                }, cancellationToken);
                if (testResult.Response is { Success: true, TestResult: not null })
                {
                    existingSolution.FirstPublishDate = DateTime.UtcNow;
                    var score = await ratingService.ApplyScoreFromCompletedTask(
                        userId.Value,
                        testResult.Response.TestResult,
                        await taskRepository.GetById(request.TaskId));
                    if (score.HasValue)
                        return responseFactory.SuccessResponse(new SimpleResponse
                        {
                            Message = $"За ваше решение назначено {score.Value} баллов"
                        });
                }
            }
            catch
            {
            }
        }
        await repository.UpdateSolution(existingSolution);
        return responseFactory.SuccessResponse(new SimpleResponse { Message = "Статус публикации решения изменен" });
    }
}