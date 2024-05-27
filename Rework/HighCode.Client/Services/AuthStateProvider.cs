using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace HighCode.Client.Services;

public class AuthStateProvider : AuthenticationStateProvider
{
    private AuthService authService { get; set; }

    public AuthStateProvider(AuthService authService)
    {
        this.authService = authService;
        this.authService.AuthStateChanged += (newClaims) =>
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(newClaims)));
        };
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        var claims = await authService.GetClaims();
        if (claims != null)
            identity = new ClaimsIdentity(claims, "jwt");

        var state = new AuthenticationState(new ClaimsPrincipal(identity));
        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }
}