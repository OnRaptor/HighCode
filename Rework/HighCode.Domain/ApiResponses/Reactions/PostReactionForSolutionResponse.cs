using HighCode.Domain.Models;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.Reactions;

public class PostReactionForSolutionResponse : ResponseBase
{
    public SolutionReactions SolutionReactions { get; set; }
    public int? MyReaction { get; set; }
}