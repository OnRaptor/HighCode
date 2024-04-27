using HighCode.Application.Models;
using HighCode.Application.Responses;
using HighCode.Domain.DTO;

namespace HighCode.Application.Handlers.Queries.TaskSolution.GetSolutions;

public class GetSolutionsResponse : ResponseBase
{
    public IEnumerable<SolutionDTO> Solutions { get; set; }
}