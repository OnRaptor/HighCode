using HighCode.Application.Responses;
using HighCode.Domain.DTO;

namespace HighCode.Application.ApiHandlers.Queries.TaskSolution.GetSolutions;

public class GetSolutionsResponse : ResponseBase
{
    public IEnumerable<SolutionDTO> Solutions { get; set; }
}