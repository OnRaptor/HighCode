#region

using HighCode.Application.ApiHandlers.Command.CodeTask.CreateTask;
using HighCode.Application.ApiHandlers.Command.CodeTask.DeleteTask;
using HighCode.Application.ApiHandlers.Command.CodeTask.EditTask;
using HighCode.Application.ApiHandlers.Queries.CodeTask.GetAllTasks;
using HighCode.Application.ApiHandlers.Queries.CodeTask.GetTaskById;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using HighCode.Domain.DTO;
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
    [Authorize(Roles = "Moderator")]
    [ProducesResponseType<CreateTaskResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
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
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> GetTasks(
        [FromBody] GetAllTaskQuery query,
        CancellationToken cancellationToken
    )
    {
        return await RequestAsync(query, cancellationToken);
    }

    [HttpGet]
    [ProducesResponseType<GetTaskByIdResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> GetTask(
        [FromQuery] GetTaskByIdQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "Moderator")]
    [ProducesResponseType<SimpleResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> EditTask(
        [FromBody] EditTaskCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "Moderator")]
    [ProducesResponseType<SimpleResponse>(200)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteTask(
        [FromBody] DeleteTaskCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}