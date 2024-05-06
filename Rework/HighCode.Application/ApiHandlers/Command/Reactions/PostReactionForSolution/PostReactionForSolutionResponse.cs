using HighCode.Application.Responses;
using HighCode.Domain.DTO;

namespace HighCode.Application.ApiHandlers.Command.Reactions.PostReactionForSolution;

public class PostReactionForSolutionResponse : ResponseBase
{
    public SolutionReactions SolutionReactions { get; set; }
}