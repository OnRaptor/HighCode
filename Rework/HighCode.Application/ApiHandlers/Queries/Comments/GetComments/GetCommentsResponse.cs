using HighCode.Application.Responses;
using HighCode.Domain.DTO;

namespace HighCode.Application.ApiHandlers.Queries.Comments.GetComments;

public class GetCommentsResponse : ResponseBase
{
    public IEnumerable<CommentDTO> Comments { get; set; }
    public int Count { get; set; }
}