using HighCode.Application.Responses;
using MediatR;

namespace HighCode.Application.ApiHandlers.Command.Comments.DeleteComment;

public class DeleteCommentCommand : IRequest<Result<DeleteCommentResponse>>
{
    public Guid Id { get; set; }
}