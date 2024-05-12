#region

using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Tasks;
using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace HighCode.API.Controllers;

[Route("api/tasks/[action]")]
public class TasksController(
    IMediator _mediator,
    ILogger<TasksController> logger,
    CorrelationContext _correlationContext)
    : BaseApiController<TasksController>(_mediator, logger)
{
    [HttpPost]
    [Authorize("StaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> CreateTask(
        [FromBody] TaskDTO task,
        CancellationToken cancellationToken)
    {
        var command = new CreateTaskCommand
        {
            Task = task,
            UserId = _correlationContext.GetUserId().Value
        };
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType<GetAllTaskResponse>(200)]
    public async Task<IActionResult> GetTasks(
        [FromBody] GetAllTaskQuery query,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(query, cancellationToken);
    }

    [HttpGet]
    [ProducesResponseType<GetTaskByIdResponse>(200)]
    public async Task<IActionResult> GetTask(
        [FromQuery] GetTaskByIdQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize("StaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> EditTask(
        [FromBody] EditTaskCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpGet]
    [ProducesResponseType<GetPopularTasksResponse>(200)]
    public async Task<IActionResult> GetPopularTasks(
        [FromQuery] GetPopularTasksQuery query,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(query, cancellationToken);
    }

    /*[HttpPost]
    [Authorize(policy: "ForStaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> DeleteTask(
        [FromBody] DeleteTaskCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }*/
}