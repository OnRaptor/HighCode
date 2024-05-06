#region

using HighCode.Domain.Constants;
using HighCode.Domain.Responses;

#endregion

namespace HighCode.Domain.ApiResponses.Auth;

public class LoginCommandResponse : ResponseBase
{
    public string? Token { get; set; }
    public UserRoleTypes Role { get; set; }
    public DateTime? ValidTo { get; set; }
}