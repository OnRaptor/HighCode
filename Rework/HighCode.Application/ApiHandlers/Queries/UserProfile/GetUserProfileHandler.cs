using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.UserProfile;
using HighCode.Domain.ApiResponses.UserProfile;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Queries.UserProfile;

public class GetUserProfileHandler(
    ResponseFactory<GetUserProfileResponse> responseFactory,
    CorrelationContext correlationContext,
    StatisticRepository statisticRepository,
    SolutionRepository solutionRepository,
    UserRepository userRepository
)
    : IRequestHandler<GetUserProfileQuery, Result<GetUserProfileResponse>>
{
    public async Task<Result<GetUserProfileResponse>> Handle(GetUserProfileQuery request,
        CancellationToken cancellationToken)
    {
        var userId = correlationContext.GetUserId().GetValueOrDefault();
        if (userId == null) return responseFactory.UnAuthResponse();

        var user = await userRepository.GetUserByIdAsync(userId);
        if (user == null) return responseFactory.UnAuthResponse();

        var userSolutions = await solutionRepository.GetSolutionsForUser(userId);
        return responseFactory.SuccessResponse(new GetUserProfileResponse
        {
            Statistics = new GetUserProfileResponse.StatisticsForUser(
                await statisticRepository.GetCompletedTasksCountForUser(userId),
                await statisticRepository.GetScoreForUser(userId),
                await statisticRepository.GetRatingPositionForUser(userId)
            ),
            Solutions = userSolutions.Select(x =>
                new GetUserProfileResponse.SolvingSolutions(x.Id, x.RelatedTaskId, x.RelatedTask.Title)),
            UserName = user.UserName,
            Description = user.Description ?? ""
        });
    }
}