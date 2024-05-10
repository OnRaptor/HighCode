using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using HighCode.Client.Services;
using HighCode.Domain.Responses;

namespace HighCode.Client.HttpHandlers;

public class TokenHandler(AuthService authService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (authService.IsAuthenticated)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await authService.GetToken());
        HttpResponseMessage response = default;
        try
        {
            response = await base.SendAsync(request, cancellationToken);
            return response;
        }
        catch (Exception e)
        {
            var error = new HttpResponseMessage(HttpStatusCode.BadRequest);
            error.Content = new StringContent(JsonSerializer.Serialize(new ErrorResponse
                { ErrorMessage = "Http error " + response?.StatusCode }));
            error.RequestMessage = request;
            return error;
        }
    }
}