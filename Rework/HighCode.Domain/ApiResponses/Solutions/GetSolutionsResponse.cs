using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.Solutions;

public class GetSolutionsResponse : ResponseBase
{
    public IEnumerable<SolutionDTO> Solutions { get; set; }
}