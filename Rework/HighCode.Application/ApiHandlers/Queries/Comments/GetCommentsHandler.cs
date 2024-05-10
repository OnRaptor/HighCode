using AutoMapper;
using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Comments;
using HighCode.Domain.ApiResponses.Comments;
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
        var comments = new List<Comment>();
        if (request.RelatedTaskId.HasValue)
            comments.AddRange(await commentRepository.GetForTask(request.RelatedTaskId.Value));
        else if (request.RelatedCommentId.HasValue)
            comments.AddRange(await commentRepository.GetForComment(request.RelatedCommentId.Value));
        else if (request.RelatedSolutionId.HasValue)
            comments.AddRange(await commentRepository.GetForSolution(request.RelatedSolutionId.Value));

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
                var replies = await _commentRepository.GetForComment(commentDto.Id);
                commentDto.RepliesCount = replies.Count();
                return commentDto;
            }))
        });
    }
}