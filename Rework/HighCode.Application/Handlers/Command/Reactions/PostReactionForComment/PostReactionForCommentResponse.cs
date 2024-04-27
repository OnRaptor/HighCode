using HighCode.Application.Responses;

namespace HighCode.Application.Handlers.Command.Reactions.PostReactionForComment;

public class PostReactionForCommentResponse : ResponseBase
{
    public int LikesCount { get; set; }
    public int DislikesCount { get; set; }
}