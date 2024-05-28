using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Admin;

public class ChangeUserRoleCommand : IRequest<Result<SimpleResponse>>
{
    public Guid UserId { get; set; }
    public int Role { get; set; }
}