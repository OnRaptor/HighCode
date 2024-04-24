#region

using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Domain.DTO;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Queries.CodeTask.GetTaskById;

public class GetTaskByIdHandler(
    ResponseFactory<GetTaskByIdResponse> responseFactory,
    TaskRepository repository
) : IRequestHandler<GetTaskByIdQuery, Result<GetTaskByIdResponse>>
{
    public async Task<Result<GetTaskByIdResponse>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetById(request.Id);
        if (result == null)
            return responseFactory.BadRequestResponse("Не удалось найти задачу");

        var task = new TaskDTO()
        {
            Title = result.Title,
            Description = result.Description,
            UnitTestCode = result.UnitTestCode,
            Complexity = result.Complexity,
            ProgrammingLanguage = result.ProgrammingLanguage,
            TemplateFuncSignature = result.TemplateFuncSignature
        };
        return responseFactory.SuccessResponse(new GetTaskByIdResponse { Task = task });
    }
}