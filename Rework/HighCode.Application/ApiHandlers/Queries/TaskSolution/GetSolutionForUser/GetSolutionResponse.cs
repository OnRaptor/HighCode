#region

using HighCode.Application.Responses;
using HighCode.Domain.DTO;

#endregion

namespace HighCode.Application.ApiHandlers.Queries.TaskSolution.GetSolutionForUser;

public class GetSolutionResponse : ResponseBase
{
    public SolutionDTO Solution { get; set; }
}