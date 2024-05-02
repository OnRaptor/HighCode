using HighCode.Infrastructure.Entities;

namespace HighCode.Application.Models;

public record LoginUserResult(bool success, string? token = null, string? message = null, RoleType? role = null);