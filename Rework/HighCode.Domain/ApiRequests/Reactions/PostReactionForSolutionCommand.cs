using HighCode.Domain.ApiResponses.Reactions;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Reactions;

public class PostReactionForSolutionCommand : IRequest<Result<PostReactionForSolutionResponse>>
{
    public Guid SolutionId { get; set; }
    public int Reaction { get; set; }
}