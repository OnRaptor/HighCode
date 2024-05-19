using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.CollectionOfTasks;

public class AddTasksToCollectionCommand : IRequest<Result<SimpleResponse>>
{
    public Guid CollectionId { get; set; }
    public IEnumerable<TaskDTO> Tasks { get; set; }
}