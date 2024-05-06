#region

using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

#endregion

namespace HighCode.Domain.ApiResponses.Tasks;

public class GetTaskByIdResponse : ResponseBase
{
    public TaskDTO Task { get; set; }
    public bool? IsTestingAvailable { get; set; }
}