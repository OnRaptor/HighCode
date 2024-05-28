#region

using System.Data.Common;
using HighCode.Application.Models;
using HighCode.Domain.Constants;
using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

#endregion

namespace HighCode.Application.Repositories;

public class UserRepository(AppDbContext _context)
{
    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> FindUserByLogin(string login)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Login == login);
    }

    public async Task<CreateUserResult> CreateUserAsync(User user)
    {
        var match = await FindUserByLogin(user.Login);
        if (match != null) return new CreateUserResult(false, true, null);

        await _context.Users.AddAsync(user);
        try
        {
            await _context.SaveChangesAsync();
            return new CreateUserResult(true, false, user.Id);
        }
        catch (DbUpdateException ex)
        {
            return new CreateUserResult(false, false, null);
        }
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbException ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsers(string searchQuery)
    {
        return await _context.Users
            .AsNoTracking()
            .Where(x => x.UserName.ToLower().Contains(searchQuery.ToLower()))
            .ToListAsync();
    }

    public async Task<bool> ChangeUserRole(Guid userId, UserRoleTypes role)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return false;
        user.Role = role;
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbException ex)
        {
            return false;
        }
    }
}