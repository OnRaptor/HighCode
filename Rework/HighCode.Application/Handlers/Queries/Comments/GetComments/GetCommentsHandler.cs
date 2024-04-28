using HighCode.Application.Handlers.Queries.Comments.GetComments;
using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using HighCode.Domain.DTO;
using HighCode.Infrastructure.Entities;
using MediatR;
using ReactionType = HighCode.Domain.DTO.ReactionType;

public class GetCommentsHandler(
    ResponseFactory<GetCommentsResponse> responseFactory,
    CommentRepository commentRepository,
    ReactionRepository reactionRepository,
    CorrelationContext correlationContext
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
            Comments = await Task.WhenAll(comments.Select(async c => new CommentDTO()
            {
                Id = c.Id,
                Content = c.Content,
                AuthorName = c.Author.UserName,
                RepliedAuthorName = c.AnotherAuthor,
                CreatedDate = c.DateCreated,
                Likes = await reactionRepository.GetLikesForComment(c.Id),
                Dislikes = await reactionRepository.GetDislikesForComment(c.Id),
                MyReaction = await reactionRepository
                    .GetReactionCommentForUser(
                        c.Id,
                        correlationContext.GetUserId().GetValueOrDefault())
            })),
            Count = comments.Count
        });
    }
}