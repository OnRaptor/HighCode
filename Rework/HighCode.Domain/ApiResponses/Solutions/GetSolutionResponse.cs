#region

using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

#endregion

namespace HighCode.Domain.ApiResponses.Solutions;

public class GetSolutionResponse : ResponseBase
{
    public SolutionDTO Solution { get; set; }
}