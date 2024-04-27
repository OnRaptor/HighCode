using HighCode.Application.Handlers.Command.Comments.DeleteComment;
using HighCode.Application.Repositories;
using HighCode.Application.Responses;
using HighCode.Application.Services;
using HighCode.Infrastructure.Entities;
using MediatR;

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
        if (correlationContext.GetUserRole() == RoleType.User.ToString() 
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