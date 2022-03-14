using UsersApi.Core.Entity;

namespace UsersApi.Core.Contracts.Repositories;

public interface IUsersRepository : IBaseRepository<User, string>
{
    Task<List<User>> GetUsersAsync(int? pageNumber, int? userTypeId, DateTime? createdDate, bool? onlySessionsMoreTwo);

    Task<bool> IsExistAsync(User user);

    Task<bool> IsExistByIdAsync(string id);

    Task<User?> FindUserByUserNameOrEmailAsync(string userNameOrEmail);
}