using HighCode.Application.Responses;
using HighCode.Infrastructure.Entities;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.Reactions.PostReactionForSolution;

public class PostReactionForSolutionCommand : IRequest<Result<PostReactionForSolutionResponse>>
{
    public Guid SolutionId { get; set; }
    public SolutionReactionType Reaction { get; set; }
}