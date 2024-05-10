using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.UserProfile;

public class GetUserProfileResponse : ResponseBase
{
    public record StatisticsForUser(int completedTasks, double? ratingsScore, int? ratingsPosition);

    public StatisticsForUser Statistics { get; set; }

    public record SolvingSolutions(Guid SolutionId, Guid TaskId, string Title);

    public IEnumerable<SolvingSolutions> Solutions { get; set; }

    public string UserName { get; set; }
    public string Description { get; set; }
}