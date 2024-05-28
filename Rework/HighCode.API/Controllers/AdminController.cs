using HighCode.Domain.ApiRequests.Admin;
using HighCode.Domain.ApiResponses.Admin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleResponse = HighCode.Domain.Responses.SimpleResponse;

namespace HighCode.API.Controllers;

[Route("api/comments/[action]")]
[ApiController]
public class AdminController(IMediator _mediator, ILogger<CollectionOfTasksController> logger)
    : BaseApiController<CollectionOfTasksController>(_mediator, logger)
{
    [HttpPost]
    [Authorize("StaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> ChangeUserRole(
        [FromBody] ChangeUserRoleCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpGet]
    [Authorize("StaffOnly")]
    [ProducesResponseType<GetUsersResponse>(200)]
    public async Task<IActionResult> GetUsers(
        [FromQuery] GetUsersQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}