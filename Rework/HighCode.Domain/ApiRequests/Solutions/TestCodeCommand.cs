#region

using HighCode.Domain.ApiResponses.Solutions;
using HighCode.Domain.Responses;
using MediatR;

#endregion

namespace HighCode.Domain.ApiRequests.Solutions;

public class TestCodeCommand : IRequest<Result<TestCodeResponse>>
{
    public string Code { get; set; }
    public Guid TaskId { get; set; }
}