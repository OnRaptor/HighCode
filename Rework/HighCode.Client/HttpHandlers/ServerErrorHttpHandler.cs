using System.Net;
using System.Text.Json;
using HighCode.Domain.Responses;

namespace HighCode.Client.HttpHandlers;

public class ServerErrorHttpHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
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
                { ErrorMessage = "Не удалось отправить запрос" + response?.StatusCode }));
            error.RequestMessage = request;
            return error;
        }
    }
}