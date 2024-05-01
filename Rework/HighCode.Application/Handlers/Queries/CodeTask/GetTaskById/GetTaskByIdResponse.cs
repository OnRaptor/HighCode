#region

using HighCode.Application.Responses;
using HighCode.Domain.DTO;

#endregion

namespace HighCode.Application.Handlers.Queries.CodeTask.GetTaskById;

public class GetTaskByIdResponse : ResponseBase
{
    public TaskDTO Task { get; set; }
    public bool? IsTestingAvailable { get; set; }
}