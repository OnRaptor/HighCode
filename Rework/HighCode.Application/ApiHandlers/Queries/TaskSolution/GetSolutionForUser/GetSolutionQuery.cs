#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Queries.TaskSolution.GetSolutionForUser;

public class GetSolutionQuery : IRequest<Result<GetSolutionResponse>>
{
    public Guid TaskId { get; set; }
}