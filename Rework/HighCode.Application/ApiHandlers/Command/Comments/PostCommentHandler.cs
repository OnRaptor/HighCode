using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Comments;
using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.Constants;
using HighCode.Domain.Responses;
using HighCode.Infrastructure.Entities;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.Comments;

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
        if (!request.RelatedTargetId.HasValue)
            return responseFactory.BadRequestResponse("Не указан идентификатор цели комментария");

        comment.RelatedTargetId = request.RelatedTargetId.GetValueOrDefault();
        comment.TargetType = (TargetTypeForComment)request.TargetType;
        
        if (!string.IsNullOrEmpty(request.AnotherAuthorName))
            comment.AnotherAuthor = request.AnotherAuthorName;
        
        return await commentsRepository.Add(comment) == null ? 
            responseFactory.ConflictResponse("Не удалось создать комментарий") : 
            responseFactory.SuccessResponse(new() { Message = "Комментарий успешно создан" });
    }
}