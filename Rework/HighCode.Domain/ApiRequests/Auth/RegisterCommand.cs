#region

using HighCode.Domain.ApiResponses.Auth;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Auth;

public class RegisterCommand : IRequest<Result<RegisterCommandResponse>>
{
    public string Login { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}