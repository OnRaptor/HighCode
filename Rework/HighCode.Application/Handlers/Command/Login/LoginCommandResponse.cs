#region

using HighCode.Application.Responses;

#endregion

namespace HighCode.Application.Handlers.Command.Login;

public class LoginCommandResponse : ResponseBase
{
    public string? Message { get; set; }
    public string? Token { get; set; }
}