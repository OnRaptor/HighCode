#region

using HighCode.Application.Responses;

#endregion

namespace HighCode.Application.Handlers.Queries.CodeTask.GetAllTasks;

public class GetAllTaskResponse : ResponseBase
{
    public IEnumerable<Infrastructure.Entities.CodeTask> Tasks { get; set; }
    public int Count { get; set; }
}