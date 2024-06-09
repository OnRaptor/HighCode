using HighCode.Domain.Constants;
using HighCode.Infrastructure;
using HighCode.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Application.Repositories;

public class StoreValuesRepository(AppDbContext dbContext)
{
    public async Task<List<StoreValue>> GetAllStoreValues()
    {
        return await dbContext
            .StoreValues
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<StoreValue>> GetStoreValuesByType(StoreValueType type)
    {
        return await dbContext
            .StoreValues
            .AsNoTracking()
            .Where(x => x.Type == type)
            .ToListAsync();
    }

    public async Task<StoreValue?> GetStoreValue(Guid id)
    {
        return await dbContext.StoreValues.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddStoreValue(StoreValue storeValue)
    {
        await dbContext.StoreValues.AddAsync(storeValue);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteStoreValue(Guid id)
    {
        dbContext.StoreValues.Remove(await GetStoreValue(id));
        await dbContext.SaveChangesAsync();
    }
}