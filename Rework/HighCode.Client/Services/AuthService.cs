using Blazored.LocalStorage;

namespace HighCode.Client.Services;

public class AuthService(ILocalStorageService localStorage)
{
    public async Task<bool> IsAuthenticated()
    {
        var tokenValid = await localStorage.GetItemAsync<DateTime?>("tokenValid");
        return tokenValid.HasValue && tokenValid < DateTime.Now;
    }

    public async Task SaveToken(string token, DateTime validTo)
    {
        await localStorage.SetItemAsStringAsync("token", token);
        await localStorage.SetItemAsync("tokenValid", validTo);
    }

    public async Task RemoveToken()
    {
        await localStorage.RemoveItemAsync("token");
        await localStorage.RemoveItemAsync("tokenValid");
    }
}