using System.Net;
using HighCode.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

public class BaseApiController<TController>
    (IMediator mediator, ILogger<TController> logger) : ControllerBase
    where TController : ControllerBase
{
    protected IMediator _mediator { get; } = mediator;
    protected readonly ILogger<TController> _logger = logger;
    
    [NonAction]
    protected async Task<IActionResult> RequestAsync<TResponse>(
        IRequest<Result<TResponse>> request,
        CancellationToken cancellationToken) where TResponse : ResponseBase
    {
        var response = await _mediator.Send(request, cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => BadRequest(response.Error),
            HttpStatusCode.Conflict => Conflict(response.Error),
            _ => Ok(response.Response)
        };
    }
    
    [NonAction]
    protected async Task<IActionResult> RequestAsync(
        IRequest<Result> request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => BadRequest(response.Error),
            HttpStatusCode.Conflict => Conflict(response.Error),
            _ => Ok(response.Response)
        };
    }
}