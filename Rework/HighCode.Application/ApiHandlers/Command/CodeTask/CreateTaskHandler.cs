#region

using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Tasks;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.CodeTask;

public class CreateTaskHandler(
    TaskRepository taskRepository,
    IMapper mapper,
    CorrelationContext correlationContext,
    ResponseFactory<SimpleResponse> responseFactory)
    : IRequestHandler<CreateTaskCommand, Result<SimpleResponse>>
{
    public async Task<Result<SimpleResponse>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = mapper.Map<Infrastructure.Entities.CodeTask>(request.Task);
        task.CreateDate = DateTime.UtcNow;
        task.AuthorId = correlationContext.GetUserId();
        if (await taskRepository.CreateTask(task))
            return responseFactory.SuccessResponse(new SimpleResponse { Message = "Задача успешно создана" });
        return responseFactory.BadRequestResponse("Не удалось создать задачу");
    }
}