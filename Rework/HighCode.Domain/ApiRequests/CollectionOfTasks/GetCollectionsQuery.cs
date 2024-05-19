using HighCode.Domain.ApiResponses.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.CollectionOfTasks;

public class GetCollectionsQuery : IRequest<Result<GetCollectionsResponse>>
{
    public bool UnPublishedOnly { get; set; }
}