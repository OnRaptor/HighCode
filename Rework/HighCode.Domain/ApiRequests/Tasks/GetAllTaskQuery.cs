#region

using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.Models;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Tasks;

public class GetAllTaskQuery : IRequest<Result<GetAllTaskResponse>>
{
    public record FilterType(string Type, string Value);

    public GetAllGroupTypes GroupType { get; set; }
    public string? SearchQuery { get; set; }
    public IEnumerable<FilterType>? Filters { get; set; }
}