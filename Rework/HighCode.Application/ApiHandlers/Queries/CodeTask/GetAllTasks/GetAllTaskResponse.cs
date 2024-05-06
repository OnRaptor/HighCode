#region

using HighCode.Application.Responses;
using HighCode.Domain.DTO;

#endregion

namespace HighCode.Application.ApiHandlers.Queries.CodeTask.GetAllTasks;

public class GetAllTaskResponse : ResponseBase
{
    public IEnumerable<TaskDTO> Tasks { get; set; }
}