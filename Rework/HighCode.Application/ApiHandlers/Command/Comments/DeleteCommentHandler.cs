using HighCode.Application.Repositories;
using HighCode.Application.Services;
using HighCode.Domain.ApiRequests.Comments;
using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.Constants;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.Comments;

public class DeleteCommentHandler(
    ResponseFactory<DeleteCommentResponse> responseFactory,
    CorrelationContext correlationContext,
    CommentRepository commentRepository
)
    : IRequestHandler<DeleteCommentCommand, Result<DeleteCommentResponse>>
{
    public async Task<Result<DeleteCommentResponse>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetById(request.Id);
        if (correlationContext.GetUserRole() == UserRoleTypes.User 
            && comment.AuthorId != correlationContext.GetUserId())
            return responseFactory.BadRequestResponse("У вас нет доступа");
        
        return await commentRepository.Delete(request.Id) ?
            responseFactory.SuccessResponse(new()
            {
                Message = "Комментарий удален"
            }) : 
            responseFactory.ConflictResponse("Не удалось удалить комментарий");
    }
}