#region

using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Solutions;

public class ChangeSolutionPublishCommand : IRequest<Result<SimpleResponse>>
{
    public Guid TaskId { get; set; }
    public bool IsPublish { get; set; }
}