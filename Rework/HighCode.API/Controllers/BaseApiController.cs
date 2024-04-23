using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BaseApiController<TController> : ControllerBase where TController : ControllerBase
{
    protected IMediator _mediator { get; }
    protected readonly ILogger<TController> _logger;

    public BaseApiController(IMediator mediator, ILogger<TController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    
}