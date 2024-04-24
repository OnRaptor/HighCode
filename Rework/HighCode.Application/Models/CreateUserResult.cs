namespace HighCode.Application.Models;

public record CreateUserResult(bool Success, bool UserExist, Guid? UserId)
{
    public string? Token { get; set; }
}