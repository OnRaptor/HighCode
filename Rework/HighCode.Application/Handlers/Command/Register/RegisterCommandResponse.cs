#region

using HighCode.Application.Responses;
using HighCode.Infrastructure.Entities;

#endregion

namespace HighCode.Application.Handlers.Command.Register;

public class RegisterCommandResponse : ResponseBase
{
    public string Token { get; set; }
    public RoleType Role { get; set; }
    public DateTime? ValidTo { get; set; }
}