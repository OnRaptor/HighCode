#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.Handlers.Queries.CodeTask.GetAllTasks;

public record GetAllTaskQuery : IRequest<Result<GetAllTaskResponse>>;