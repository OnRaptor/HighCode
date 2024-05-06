#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Queries.CodeTask.GetAllTasks;

public class GetAllTaskQuery : IRequest<Result<GetAllTaskResponse>>
{
    public record FilterType(string Type, string Value);

    public bool? IsUnPublishedOnly { get; set; }
    public string? SearchQuery { get; set; }
    public IEnumerable<FilterType>? Filters { get; set; }
}