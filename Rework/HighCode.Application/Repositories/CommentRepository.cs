using HighCode.Domain.Constants;
using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Application.Repositories;

public class CommentRepository(AppDbContext _context)
{
    public async Task<Guid?> Add(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        try
        {
            await _context.SaveChangesAsync();
            return comment.Id;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> Delete(Guid commentId) 
        => await _context.Comments.Where(c => c.Id == commentId).ExecuteDeleteAsync() > 0;
    
    
    public async Task<Comment?> GetById(Guid commentId)
    {
        return await _context.Comments.AsNoTracking().Include(c => c.Author)
            .Where(c => c.Id == commentId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Comment>> GetCommentsForType(TargetTypeForComment typeForComment, Guid targetId)
    {
        return await _context.Comments
            .AsNoTracking()
            .Include(c => c.Author)
            .Where(c => c.TargetType == typeForComment && c.RelatedTargetId == targetId)
            .ToListAsync();
    }
}