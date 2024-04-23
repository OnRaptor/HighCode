using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HighCode.Application.Common;
using Microsoft.IdentityModel.Tokens;

namespace HighCode.Application.Common;

public class JwtGenerator
{
    public static string GenerateToken(string userId, string userName)
    {
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Jti, userId),
            new (JwtRegisteredClaimNames.Name, userName)
        };
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}