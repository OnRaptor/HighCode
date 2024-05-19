using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.CollectionOfTasks;

public class GetTaskInCollectionResponse : ResponseBase
{
    public IEnumerable<TaskDTO> Tasks { get; set; }
}