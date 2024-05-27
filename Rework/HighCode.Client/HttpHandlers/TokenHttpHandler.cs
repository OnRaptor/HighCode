using HighCode.Client.Services;

namespace HighCode.Client.HttpHandlers;

public class TokenHttpHandler(AuthService authService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await authService.GetToken());
        return await base.SendAsync(request, cancellationToken);
    }
}