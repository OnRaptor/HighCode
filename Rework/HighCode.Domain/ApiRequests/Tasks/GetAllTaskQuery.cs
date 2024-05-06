#region

using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Tasks;

public class GetAllTaskQuery : IRequest<Result<GetAllTaskResponse>>
{
    public record FilterType(string Type, string Value);

    public bool? IsUnPublishedOnly { get; set; }
    public string? SearchQuery { get; set; }
    public IEnumerable<FilterType>? Filters { get; set; }
}