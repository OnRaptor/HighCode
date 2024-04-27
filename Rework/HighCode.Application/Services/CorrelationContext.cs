#region

using System.Security.Claims;
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

    public string GetUserRole()
    {
        var context = httpContextAccessor.HttpContext;

        return context?.User.FindFirstValue(ClaimTypes.Role);
    }
}