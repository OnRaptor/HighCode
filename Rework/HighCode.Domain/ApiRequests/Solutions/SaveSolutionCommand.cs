#region

using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Solutions;

public class SaveSolutionCommand : IRequest<Result<SimpleResponse>>
{
    public string Code { get; set; }
    public Guid TaskId { get; set; }
}