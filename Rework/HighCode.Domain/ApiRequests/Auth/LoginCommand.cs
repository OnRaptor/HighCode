#region

using HighCode.Domain.ApiResponses.Auth;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Auth;

public class LoginCommand : IRequest<Result<LoginCommandResponse>>
{
    public string Login { get; set; }
    public string Password { get; set; }
}