#region

using System.ComponentModel;
using HighCode.Domain.Constants;

#endregion

namespace HighCode.Infrastructure.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string UserName { get; set; }
    public string? Description { get; set; }

    [DefaultValue("1")] public UserRoleTypes Role { get; set; }

    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}