#region

using System.Net;
using HighCode.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace HighCode.API.Controllers;

[ApiController]
[Produces("application/json")]
[ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
public class BaseApiController<TController>(
    IMediator _mediator,
    ILogger<TController> logger) : ControllerBase
    where TController : ControllerBase
{
    [NonAction]
    protected async Task<IActionResult> RequestAsync<TResponse>(
        IRequest<Result<TResponse>> request,
        CancellationToken cancellationToken) where TResponse : ResponseBase
    {
        logger.LogInformation($"Sending request {HttpContext.Request.QueryString.Value} to {request}");
        var response = await _mediator.Send(request, cancellationToken);
        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => BadRequest(response.Error),
            HttpStatusCode.Conflict => Conflict(response.Error),
            _ => Ok(response.Response)
        };
    }
}