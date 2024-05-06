using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Reactions;
using HighCode.Domain.ApiResponses.Reactions;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.Reactions;

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
                request.CommentReaction,
                userId))
            return responseFactory.SuccessResponse(new()
            {
                DislikesCount = await repository.GetDislikesForComment(request.CommentId),
                LikesCount = await repository.GetLikesForComment(request.CommentId)
            });

        return responseFactory.BadRequestResponse("Не удалось добавить реакцию на комментарий");
    }
}