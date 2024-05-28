using HighCode.Domain.DTO;
using HighCode.Domain.Responses;

namespace HighCode.Domain.ApiResponses.Admin;

public class GetUsersResponse : ResponseBase
{
    public IEnumerable<UserDTO> Users { get; set; }
}