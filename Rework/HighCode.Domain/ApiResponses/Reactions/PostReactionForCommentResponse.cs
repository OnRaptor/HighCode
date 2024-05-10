using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.Reactions;

public class PostReactionForCommentResponse : ResponseBase
{
    public int LikesCount { get; set; }
    public int DislikesCount { get; set; }
    public int? MyReaction { get; set; }
}