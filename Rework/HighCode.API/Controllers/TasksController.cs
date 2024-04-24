#region

using HighCode.Application.Handlers.Command.CodeTask.CreateTask;
using HighCode.Application.Handlers.Command.CodeTask.DeleteTask;
using HighCode.Application.Handlers.Command.CodeTask.EditTask;
using HighCode.Application.Handlers.Queries.CodeTask.GetAllTasks;
using HighCode.Application.Handlers.Queries.CodeTask.GetTaskById;
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
    : BaseApiController<TasksController>(_mediator, logger, _correlationContext)
{
    [HttpPost]
    [Authorize(Roles = "Moderator")]
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

    [HttpGet]
    public async Task<IActionResult> GetTasks(CancellationToken cancellationToken)
    {
        return await RequestAsync(new GetAllTaskQuery(), cancellationToken);
    }

    [HttpGet]
    public async Task<IActionResult> GetTask(
        [FromQuery] GetTaskByIdQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "Moderator")]
    public async Task<IActionResult> EditTask(
        [FromBody] EditTaskCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "Moderator")]
    public async Task<IActionResult> DeleteTask(
        [FromBody] DeleteTaskCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}