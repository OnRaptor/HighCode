using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.CollectionOfTasks;

public class GetCollectionsResponse : ResponseBase
{
    public IEnumerable<CollectionOfTasksDTO> Collections { get; set; }
}