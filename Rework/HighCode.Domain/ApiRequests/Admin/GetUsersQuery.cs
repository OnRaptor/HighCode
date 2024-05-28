using HighCode.Domain.ApiResponses.Admin;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Admin;

public class GetUsersQuery : IRequest<Result<GetUsersResponse>>
{
    public string? searchQuery { get; set; }
}