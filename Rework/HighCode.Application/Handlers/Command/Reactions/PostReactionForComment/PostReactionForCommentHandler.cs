using HighCode.Application.Handlers.Command.Reactions.PostReactionForComment;
using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using MediatR;

public class PostReactionForCommentHandler(
    ResponseFactory<PostReactionForCommentResponse> responseFactory,
    ReactionRepository repository,
    CorrelationContext correlationContext)
    : IRequestHandler<PostReactionForCommentCommand, Result<PostReactionForCommentResponse>>
{
    public async Task<Result<PostReactionForCommentResponse>> Handle(PostReactionForCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = correlationContext.GetUserId().GetValueOrDefault();
        if (await repository.ApplyReactionToComment(
                request.CommentId,
                request.Reaction,
                userId))
            return responseFactory.SuccessResponse(new()
            {
                DislikesCount = await repository.GetDislikesForComment(request.CommentId),
                LikesCount = await repository.GetLikesForComment(request.CommentId)
            });

        return responseFactory.BadRequestResponse("Не удалось добавить реакцию на комментарий");
    }
}