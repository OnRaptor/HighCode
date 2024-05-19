using HighCode.Domain.ApiRequests.CollectionOfTasks;
using HighCode.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.API.Controllers;

public class CollectionOfTasksController(IMediator _mediator, ILogger<CommentsController> logger)
    : BaseApiController<CommentsController>(_mediator, logger)
{
    [HttpPost]
    [Authorize("StaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> CreateCollection(
        [FromBody] CreateCollectionCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize("StaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> EditCollection(
        [FromBody] EditCollectionCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize("StaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> AddTasksToCollection(
        [FromBody] AddTasksToCollectionCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpPost]
    [Authorize("StaffOnly")]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> RemoveTaskFromCollection(
        [FromBody] RemoveTaskFromCollectionCommand command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpGet]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> GetCollections(
        [FromBody] GetCollectionsQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }

    [HttpGet]
    [ProducesResponseType<SimpleResponse>(200)]
    public async Task<IActionResult> GetTasksInCollection(
        [FromBody] GetTaskInCollectionQuery command,
        CancellationToken cancellationToken)
    {
        return await RequestAsync(command, cancellationToken);
    }
}