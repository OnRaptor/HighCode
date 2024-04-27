using HighCode.Application.Handlers.Command.Comments.DeleteComment;
using HighCode.Application.Responses;
using MediatR;

public class DeleteCommentCommand : IRequest<Result<DeleteCommentResponse>>
{
    public Guid Id { get; set; }
}