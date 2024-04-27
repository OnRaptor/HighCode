using System.Collections;
using HighCode.Application.Responses;
using HighCode.Domain.DTO;
using HighCode.Infrastructure.Entities;

namespace HighCode.Application.Handlers.Queries.Comments.GetComments;

public class GetCommentsResponse : ResponseBase
{
    public IEnumerable<CommentDTO> Comments { get; set; }
    public int Count { get; set; }
}