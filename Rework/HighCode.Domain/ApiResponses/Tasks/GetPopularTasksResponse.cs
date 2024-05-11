using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.Tasks;

public class GetPopularTasksResponse : ResponseBase
{
    public record PopularTaskItem(TaskDTO Task, int solutionsCount);

    public IEnumerable<PopularTaskItem> Tasks { get; set; }
}