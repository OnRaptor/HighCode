using HighCode.Application.Handlers.Command.Reactions.PostReactionForComment;
using HighCode.Application.Responses;
using HighCode.Infrastructure.Entities;
using MediatR;

public class PostReactionForCommentCommand : IRequest<Result<PostReactionForCommentResponse>>
{
    public Guid CommentId { get; set; }
    public ReactionType Reaction { get; set; }
}