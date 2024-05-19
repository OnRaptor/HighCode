using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Comments;
using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.Constants;
using HighCode.Domain.DTO;
using HighCode.Domain.Responses;
using HighCode.Infrastructure.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HighCode.Application.ApiHandlers.Queries.Comments;

public class GetCommentsHandler(
    ResponseFactory<GetCommentsResponse> responseFactory,
    CommentRepository commentRepository,
    CorrelationContext correlationContext,
    IMapper mapper,
    IServiceProvider serviceProvider
)
    : IRequestHandler<GetCommentsQuery, Result<GetCommentsResponse>>
{
    public async Task<Result<GetCommentsResponse>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        if (!request.RelatedTargetId.HasValue)
            return responseFactory.BadRequestResponse("Не указан идентификатор цели комментария");
        var userId = correlationContext.GetUserId().GetValueOrDefault();
        var comments = new List<Comment>(await commentRepository.GetCommentsForType(
            (TargetTypeForComment)request.TargetTypeForComment, request.RelatedTargetId.GetValueOrDefault()));
        return responseFactory.SuccessResponse(new()
        {
            Comments = await Task.WhenAll(comments.Select(async c =>
            {
                var reactionRepository = serviceProvider.GetService<ReactionRepository>(); // для параллельных запросов
                var _commentRepository = serviceProvider.GetService<CommentRepository>(); // для параллельных запросов
                var commentDto = mapper.Map<CommentDTO>(c);
                commentDto.Likes = await reactionRepository.GetLikesForComment(c.Id);
                commentDto.Dislikes = await reactionRepository.GetDislikesForComment(c.Id);
                commentDto.MyReaction = await reactionRepository
                    .GetReactionCommentForUser(
                        c.Id,
                        correlationContext.GetUserId().GetValueOrDefault());
                commentDto.IsMine = c.AuthorId == userId;
                if (c.TargetType == TargetTypeForComment.Reply) //нет смысла дальше искать ответы если это итак ответ
                    return commentDto; 
                var replies = await _commentRepository.GetCommentsForType(TargetTypeForComment.Reply, c.Id);
                commentDto.RepliesCount = replies.Count();
                return commentDto;
            }))
        });
    }
}