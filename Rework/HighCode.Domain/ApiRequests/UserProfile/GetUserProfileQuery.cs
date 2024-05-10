using HighCode.Domain.ApiResponses.UserProfile;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.UserProfile;

public class GetUserProfileQuery : IRequest<Result<GetUserProfileResponse>>
{
}