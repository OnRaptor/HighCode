#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using HighCode.Infrastructure.Entities;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.TaskSolution.SaveSolution;

public class SaveSolutionHandler(
    ResponseFactory<SimpleResponse> responseFactory,
    SolutionRepository repository,
    CorrelationContext correlationContext
) : IRequestHandler<SaveSolutionCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(SaveSolutionCommand request, CancellationToken cancellationToken)
    {
        var userId = correlationContext.GetUserId();
        if (userId == null) responseFactory.BadRequestResponse("Нет доступа");
        var existingSolution = await repository.GetSolutionByTaskForUser(request.TaskId, userId.Value);
        if (existingSolution != null)
        {
            existingSolution.Code = request.Code;
            if (!await repository.UpdateSolution(existingSolution))
                return responseFactory.BadRequestResponse("Не удалось сохранить решение");
            return responseFactory.SuccessResponse(new SimpleResponse { Message = "Решение сохранено" });
        }

        var newSolution = new CodeTaskSolution()
        {
            Code = request.Code,
            AuthorId = userId.Value,
            RelatedTaskId = request.TaskId
        };
        if (!await repository.CreateSolution(newSolution))
            return responseFactory.BadRequestResponse("Не удалось сохранить решение");

        return responseFactory.SuccessResponse(new SimpleResponse { Message = "Решение сохранено" });
    }
}