#region

using HighCode.Application.Responses;

#endregion

namespace HighCode.Application.Handlers.Command.Register;

public class RegisterCommandResponse : ResponseBase
{
    public string Token { get; set; }
}