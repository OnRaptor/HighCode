using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.UserProfile;

public class BanUserCommand : IRequest<Result<SimpleResponse>>
{
    public Guid UserId { get; set; }
}