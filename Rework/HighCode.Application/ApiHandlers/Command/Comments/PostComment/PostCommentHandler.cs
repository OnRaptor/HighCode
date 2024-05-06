using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using HighCode.Infrastructure.Entities;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.Comments.PostComment;

public class PostCommentHandler(
    ResponseFactory<PostCommentResponse> responseFactory,
    CommentRepository commentsRepository,
    CorrelationContext correlationContext
)
    : IRequestHandler<PostCommentCommand, Result<PostCommentResponse>>
{
    public async Task<Result<PostCommentResponse>> Handle(PostCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Comment
        {
            Content = request.Content,
            DateCreated = DateTime.UtcNow,
            AuthorId = correlationContext.GetUserId().Value
        };
        if (request.RelatedCommentId.HasValue)
            comment.RepliedCommentId = request.RelatedCommentId.Value;
        if (request.RelatedTaskId.HasValue)
            comment.RelatedTaskId = request.RelatedTaskId.Value;
        if (request.RelatedSolutionId.HasValue)
            comment.RelatedTaskSolutionId = request.RelatedSolutionId.Value;
        if (!string.IsNullOrEmpty(request.AnotherAuthorName))
            comment.AnotherAuthor = request.AnotherAuthorName;
        
        return await commentsRepository.Add(comment) == null ? 
            responseFactory.ConflictResponse("Не удалось создать комментарий") : 
            responseFactory.SuccessResponse(new() { Message = "Комментарий успешно создан" });
    }
}