using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.Comments;

public class GetCommentsResponse : ResponseBase
{
    public IEnumerable<CommentDTO> Comments { get; set; }
    public int Count { get; set; }
}