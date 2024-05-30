using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.LocalStorage;
using HighCode.Domain.Constants;

namespace HighCode.Client.Services;

public class AuthService(ILocalStorageService localStorage, HttpClient http, ILogger<AuthService> logger)
{
    public UserRoleTypes? CurrentRole { get; set; }
    private bool IsAuthenticated { get; set; }

    public async Task<string?> GetToken()
    {
        return await localStorage.GetItemAsStringAsync("token");
    }

    public event Action<ClaimsPrincipal>? AuthStateChanged;

    public async Task SaveAuthData(string token, DateTime validTo)
    {
        await localStorage.SetItemAsStringAsync("token", token);
        await localStorage.SetItemAsync("tokenValid", validTo);
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        AuthStateChanged?.Invoke(new ClaimsPrincipal(new ClaimsIdentity(GetClaims(token), "jwt")));
    }

    private async Task<bool> ValidateToken()
    {
        var tokenValid = await localStorage.GetItemAsync<DateTime?>("tokenValid");
        IsAuthenticated = tokenValid.HasValue && tokenValid.Value.ToUniversalTime() > DateTime.UtcNow;
        if (IsAuthenticated)
            CurrentRole = await localStorage.GetItemAsync<UserRoleTypes?>("role");
        else
            await RemoveToken();

        return IsAuthenticated;
    }

    public async Task RemoveToken()
    {
        await localStorage.RemoveItemAsync("token");
        await localStorage.RemoveItemAsync("tokenValid");
        AuthStateChanged?.Invoke(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    /// <summary>
    /// Возвращает клеймы только валидного токена
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Claim>?> GetClaims()
    {
        var token = await GetToken();
        if (string.IsNullOrEmpty(token))
            return null;
        if (!await ValidateToken())
            return null;
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return GetClaims(token);
    }

    private IEnumerable<Claim>? GetClaims(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        return handler.ReadJwtToken(token).Claims;
    }
}