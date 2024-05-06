#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Queries.CodeTask.GetTaskById;

public class GetTaskByIdQuery : IRequest<Result<GetTaskByIdResponse>>
{
    public Guid Id { get; set; }
}