using HighCode.Application.Responses;
using HighCode.Infrastructure.Entities;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.Reactions.PostReactionForComment;

public class PostReactionForCommentCommand : IRequest<Result<PostReactionForCommentResponse>>
{
    public Guid CommentId { get; set; }
    public ReactionType Reaction { get; set; }
}