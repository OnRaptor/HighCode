#region

using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

#endregion

namespace HighCode.Domain.ApiResponses.Tasks;

public class GetAllTaskResponse : ResponseBase
{
    public IEnumerable<TaskDTO> Tasks { get; set; }
}