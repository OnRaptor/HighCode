using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace HighCode.Infrastructure.Entities;

public class User 
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string UserName { get; set; }
    public string? Description { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}