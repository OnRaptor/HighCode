namespace HighCode.Application.Models;

public record CreateUserResult(bool Success, bool UserExist, Guid? UserId);