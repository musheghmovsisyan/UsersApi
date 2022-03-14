using UsersApi.Core.Entity;

namespace UsersApi.Core.Contracts.Services;

public interface IUsersService
{
    Task<User> GetByIdAsync(string id);
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(string id);
    Task<List<User>> GetUsers(int? pageNumber, int? userTypeId, DateTime? createdDate, bool? onlySessionsMoreTwo);
}