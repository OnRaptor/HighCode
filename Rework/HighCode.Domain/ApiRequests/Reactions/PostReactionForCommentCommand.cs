using HighCode.Domain.ApiResponses.Reactions;
using HighCode.Domain.Models;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Reactions;

public class PostReactionForCommentCommand : IRequest<Result<PostReactionForCommentResponse>>
{
    public Guid CommentId { get; set; }
    public CommentReactionType CommentReaction { get; set; }
}