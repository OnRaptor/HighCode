using HighCode.Domain.ApiResponses.Tasks;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Tasks;

public class GetPopularTasksQuery : IRequest<Result<GetPopularTasksResponse>>
{
}