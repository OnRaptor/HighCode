#region

using System.Net;

#endregion

namespace HighCode.Domain.Responses;

public record Result<TResponse> where TResponse : ResponseBase
{
    public TResponse Response { get; init; }

    public ErrorResponse Error { get; init; }
    public HttpStatusCode StatusCode { get; init; }
}

public record Result
{
    public string Response { get; init; }

    public ErrorResponse Error { get; init; }
    public HttpStatusCode StatusCode { get; init; }
}