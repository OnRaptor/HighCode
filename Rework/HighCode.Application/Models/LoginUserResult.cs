﻿using HighCode.Domain.Constants;

namespace HighCode.Application.Models;

public record LoginUserResult(bool success, string? token = null, string? message = null, UserRoleTypes? role = null);