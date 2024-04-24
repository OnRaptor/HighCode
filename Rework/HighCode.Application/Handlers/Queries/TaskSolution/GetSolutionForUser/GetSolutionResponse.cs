#region

using HighCode.Application.Responses;
using HighCode.Domain.DTO;

#endregion

namespace HighCode.Application.Handlers.Queries.TaskSolution.GetSolutionForUser;

public class GetSolutionResponse : ResponseBase
{
    public SolutionDTO Solution { get; set; }
}