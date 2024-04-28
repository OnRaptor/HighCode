using HighCode.Application.Models;
using HighCode.Domain.DTO;
using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using ReactionType = HighCode.Infrastructure.Entities.ReactionType;

namespace HighCode.Application.Repositories;

public class ReactionRepository(AppDbContext _context)
{
    /// <summary>
    /// Добавляет или удаляет реакцию на комментарий, если она уже есть
    /// </summary>
    /// <returns>Успешна ли операция</returns>
    public async Task<bool> ApplyReactionToComment(Guid commentId, ReactionType reactionType, Guid userId)
    {
        var existingReaction = await GetReactionCommentForUser(commentId, userId);
        if (existingReaction != null)
        {
            await _context.CommentsReactions.Where(cr =>
                cr.CommentId == commentId &&
                cr.AuthorId == userId).ExecuteDeleteAsync();
            
            if (existingReaction == (int?)reactionType)
                return true;
        }
        
        //если реакцию нет, то добавляем
        await _context.CommentsReactions.AddAsync(new()
        {
            CommentId = commentId,
            AuthorId = userId,
            Reaction = reactionType
        });
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<int> GetLikesForComment(Guid commentId)
    {
        return await _context.CommentsReactions.Where(cr
            => cr.CommentId == commentId &&
               cr.Reaction == ReactionType.Like
            ).CountAsync();
    }
    
    public async Task<int> GetDislikesForComment(Guid commentId)
    {
        return await _context.CommentsReactions.Where(cr
            => cr.CommentId == commentId &&
               cr.Reaction == ReactionType.Dislike
        ).CountAsync();
    }
    
    public async Task<int?> GetReactionCommentForUser(Guid commentId, Guid userId) =>
        (int?)(await _context.CommentsReactions
            .AsNoTracking()
            .FirstOrDefaultAsync(cr => 
                cr.CommentId == commentId && 
                cr.AuthorId == userId))?.Reaction;

    public async Task<SolutionReactions> GetReactionsForSolution(Guid solutionId)
    {
        var solutionReactions = await _context.CodeTaskSolutionReactions
            .AsNoTracking()
            .Where(sr => sr.SolutionId == solutionId).ToListAsync();
        return new SolutionReactions(
            solutionReactions.Count(sr => sr.Reaction == SolutionReactionType.Interesting),
            solutionReactions.Count(sr => sr.Reaction == SolutionReactionType.Clever),
            solutionReactions.Count(sr => sr.Reaction == SolutionReactionType.Fun));
    }
    public async Task<int?> GetReactionSolutionForUser(Guid solutionId, Guid userId) =>
        (int?)(await _context.CodeTaskSolutionReactions
            .AsNoTracking()
            .FirstOrDefaultAsync(cr => 
                cr.SolutionId == solutionId && 
                cr.AuthorId == userId))?.Reaction;
    
    public async Task<bool> ApplyReactionToSolution(Guid solutionId, SolutionReactionType reactionType, Guid userId)
    {
        var existingReaction = await GetReactionSolutionForUser(solutionId, userId);
        if (existingReaction != null)
        {
            await _context.CodeTaskSolutionReactions.Where(cr =>
                cr.SolutionId == solutionId &&
                cr.AuthorId == userId).ExecuteDeleteAsync();
            
            if (existingReaction == (int?)reactionType)
                return true;
        }
        
        //если реакцию нет, то добавляем
        await _context.CodeTaskSolutionReactions.AddAsync(new()
        {
            SolutionId = solutionId,
            AuthorId = userId,
            Reaction = reactionType
        });
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}