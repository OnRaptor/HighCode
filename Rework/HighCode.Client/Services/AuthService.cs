using Blazored.LocalStorage;

namespace HighCode.Client.Services;

public class AuthService(ILocalStorageService localStorage)
{
    public RoleType? CurrentRole { get; set; }
    public bool IsAuthenticated { get; set; }
    
    public async Task<string?> GetToken() => await localStorage.GetItemAsStringAsync("token");

    public async Task SaveAuthData(string token, DateTime validTo, RoleType role)
    {
        await localStorage.SetItemAsStringAsync("token", token);
        await localStorage.SetItemAsync("tokenValid", validTo);
        await localStorage.SetItemAsync("role", role);
    }

    public async Task Init()
    {
        var tokenValid = await localStorage.GetItemAsync<DateTime?>("tokenValid");
        IsAuthenticated = tokenValid.HasValue && tokenValid > DateTime.UtcNow;
        if (IsAuthenticated)
            CurrentRole = await localStorage.GetItemAsync<RoleType?>("role");
    }

    public async Task RemoveToken()
    {
        await localStorage.RemoveItemAsync("token");
        await localStorage.RemoveItemAsync("tokenValid");
        await localStorage.RemoveItemAsync("role");
        IsAuthenticated = false;
        CurrentRole = null;
    }
}