#region

using System.ComponentModel;

#endregion

namespace HighCode.Infrastructure.Entities;

public enum RoleType
{
    User,
    Moderator,
    Administrator
}

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string UserName { get; set; }
    public string? Description { get; set; }

    [DefaultValue("1")] public RoleType Role { get; set; }

    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}