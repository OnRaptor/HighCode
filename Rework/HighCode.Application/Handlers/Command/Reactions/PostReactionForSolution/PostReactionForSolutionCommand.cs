using HighCode.Application.Handlers.Command.Reactions.PostReactionForSolution;
using HighCode.Application.Responses;
using HighCode.Infrastructure.Entities;
using MediatR;

public class PostReactionForSolutionCommand : IRequest<Result<PostReactionForSolutionResponse>>
{
    public Guid SolutionId { get; set; }
    public SolutionReactionType Reaction { get; set; }
}