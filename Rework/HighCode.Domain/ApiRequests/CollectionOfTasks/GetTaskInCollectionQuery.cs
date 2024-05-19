using HighCode.Domain.ApiResponses.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.CollectionOfTasks;

public class GetTaskInCollectionQuery : IRequest<Result<GetTaskInCollectionResponse>>
{
    public Guid CollectionId { get; set; }
}