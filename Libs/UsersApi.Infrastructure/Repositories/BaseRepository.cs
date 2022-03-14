using UsersApi.Core.Contracts.Repositories;
using UsersApi.Infrastructure.Data;

namespace UsersApi.Infrastructure.Repositories;

public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : class, new() where TId : class
{
    protected readonly UsersApiDbContext DbContext;

    public BaseRepository(UsersApiDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(TId id)
    {
        return await DbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        DbContext.Set<T>().Update(entity);
        await DbContext.SaveChangesAsync();
    }
}