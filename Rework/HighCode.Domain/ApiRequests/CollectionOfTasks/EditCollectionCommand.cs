using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.CollectionOfTasks;

public class EditCollectionCommand : IRequest<Result<SimpleResponse>>
{
    public CollectionOfTasksDTO Collection { get; set; }
}