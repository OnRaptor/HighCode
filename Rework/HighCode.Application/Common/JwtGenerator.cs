#region

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

#endregion

namespace HighCode.Application.Common;

public class JwtGenerator
{
    public static string GenerateToken(string userId, string userName, string role)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, userId),
            new(JwtRegisteredClaimNames.Name, userName),
            new(ClaimTypes.Role, role)
        };
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
            AuthOptions.ISSUER,
            AuthOptions.AUDIENCE,
            claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}