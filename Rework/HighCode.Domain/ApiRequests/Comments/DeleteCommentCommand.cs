using HighCode.Domain.ApiResponses.Comments;
using HighCode.Domain.Responses;
using MediatR;

namespace HighCode.Domain.ApiRequests.Comments;

public class DeleteCommentCommand : IRequest<Result<DeleteCommentResponse>>
{
    public Guid Id { get; set; }
}