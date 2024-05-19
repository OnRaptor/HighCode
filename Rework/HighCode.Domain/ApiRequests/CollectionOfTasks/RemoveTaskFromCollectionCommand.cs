using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.CollectionOfTasks;

public class RemoveTaskFromCollectionCommand : IRequest<Result<SimpleResponse>>
{
    public Guid CollectionId { get; set; }
    public Guid TaskId { get; set; }
}