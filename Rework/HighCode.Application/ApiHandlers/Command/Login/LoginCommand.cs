#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.Login;

public class LoginCommand : IRequest<Result<LoginCommandResponse>>
{
    public string Login { get; set; }
    public string Password { get; set; }
}