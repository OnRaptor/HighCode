using HighCode.Domain.Constants;

namespace HighCode.Domain.DTO;

public class UserDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Description { get; set; }
    public UserRoleTypes Role { get; set; }
}