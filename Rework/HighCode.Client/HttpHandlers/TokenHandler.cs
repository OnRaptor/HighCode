using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using HighCode.Client.Services;
using MudBlazor;

namespace HighCode.Client.HttpHandlers;

public class TokenHandler(AuthService authService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (await authService.IsAuthenticated())
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await authService.GetToken());
        try
        {
            return await base.SendAsync(request, cancellationToken);
        }
        catch (Exception e)
        {
            var error = new HttpResponseMessage(HttpStatusCode.BadRequest);
            error.Content = new StringContent(JsonSerializer.Serialize(new ErrorResponse { ErrorMessage = "Network error: \n" + e.Message }));
            error.RequestMessage = request;
            return error;
        }
    }
}