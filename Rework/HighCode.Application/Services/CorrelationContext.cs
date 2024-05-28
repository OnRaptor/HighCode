#region

using System.Security.Claims;
using HighCode.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

#endregion

namespace HighCode.Application.Services;

public class CorrelationContext
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public CorrelationContext(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public Guid? GetUserId()
    {
        var context = httpContextAccessor.HttpContext;

        var correlationContextUserId = context?.User.FindFirstValue(JwtRegisteredClaimNames.Jti);

        var parsed = Guid.TryParse(correlationContextUserId, out var parsedUserId);

        return !parsed
            ? null
            : parsedUserId;
    }

    public UserRoleTypes? GetUserRole()
    {
        var context = httpContextAccessor.HttpContext;
        if (Enum.TryParse<UserRoleTypes>(context?.User.FindFirstValue(ClaimTypes.Role), out var parsedUserRole))
            return parsedUserRole;
        return null;
    }
}