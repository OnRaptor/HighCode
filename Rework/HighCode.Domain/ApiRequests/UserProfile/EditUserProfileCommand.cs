using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.UserProfile;

public class EditUserProfileCommand : IRequest<Result<SimpleResponse>>
{
    public string? UserName { get; set; }
    public string? Description { get; set; }
}