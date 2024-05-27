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
        Result<TResponse> response = null;
        try
        {
            response = await _mediator.Send(request, cancellationToken);
            return response.StatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(response.Error),
                HttpStatusCode.Conflict => Conflict(response.Error),
                HttpStatusCode.Unauthorized => Conflict(response.Error),
                _ => Ok(response.Response)
            };
        }
        catch (Exception e)
        {
            logger.LogError(e, $"Error while sending request {HttpContext.Request.QueryString.Value} to {request}");
            return StatusCode(500, new Result
            {
                Error = new ErrorResponse { ErrorMessage = "Ошибка сервера" },
                StatusCode = HttpStatusCode.InternalServerError
            });
        }
    }
}