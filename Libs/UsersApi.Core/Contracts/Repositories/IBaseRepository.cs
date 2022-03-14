namespace UsersApi.Core.Contracts.Repositories;

public interface IBaseRepository<T, in TId> where T : class, new() where TId : class
{
    Task<T?> GetByIdAsync(TId id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}