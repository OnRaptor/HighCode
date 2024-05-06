#region

using HighCode.Application.Responses;
using MediatR;

#endregion

namespace HighCode.Application.ApiHandlers.Command.Register;

public class RegisterCommand : IRequest<Result<RegisterCommandResponse>>
{
    public string Login { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}