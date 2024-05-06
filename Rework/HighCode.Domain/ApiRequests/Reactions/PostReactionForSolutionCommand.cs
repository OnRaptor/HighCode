using HighCode.Domain.ApiResponses.Reactions;
using HighCode.Domain.Models;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Reactions;

public class PostReactionForSolutionCommand : IRequest<Result<PostReactionForSolutionResponse>>
{
    public Guid SolutionId { get; set; }
    public SolutionReactionType Reaction { get; set; }
}