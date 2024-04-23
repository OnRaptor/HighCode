using HighCode.Application.Models;
using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Application.Repositories;

public class UserRepository
{
    public readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> FindUserByLogin(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
    }

    public async Task<CreateUserResult> CreateUserAsync(User user)
    {
        var match = await FindUserByLogin(user.Login);
        if (match != null) return new(false, true, null);
        
        await _context.Users.AddAsync(user);
        try
        {
            await _context.SaveChangesAsync();
            return new(true, false, user.Id);
        }
        catch (DbUpdateException ex)
        {
            return new(false, false, null);
        }
    }
}