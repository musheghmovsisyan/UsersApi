using UsersApi.Core.Contracts.Repositories;
using UsersApi.Core.Contracts.Services;
using UsersApi.Core.Entity;
using UsersApi.Core.Exceptions;

namespace UsersApi.Core.Application.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<User> GetByIdAsync(string id)
    {
        var result = await _usersRepository.GetByIdAsync(id);

        if (result is null)
        {
            throw new RequestException("User Not exist.");
        }

        return result;
    }

    public async Task<User> AddAsync(User user)
    {
        var isExist = await _usersRepository.IsExistAsync(user);

        if (isExist)
        {
            throw new RequestException($"Already exist with email - {user.Email}");
        }

        var userAdded = await _usersRepository.AddAsync(user);

        if (userAdded.Id == new Guid().ToString())
        {
            throw new RequestException("Inserting data failed.");
        }

        userAdded = await _usersRepository.GetByIdAsync(userAdded.Id);

        return userAdded!;
    }

    public async Task UpdateAsync(User user)
    {
        var isExist = await _usersRepository.IsExistByIdAsync(user.Id);
        var isAlreadyExist = await _usersRepository.IsExistAsync(user);

        if (!isExist)
        {
            throw new RequestException("User Not exist.");
        }

        if (isAlreadyExist)
        {
            throw new RequestException($"User by Email - {user.Email} already exists.");
        }

        await _usersRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(string id)
    {
        var user = await _usersRepository.GetByIdAsync(id);
        if (user != null)
        {
            await _usersRepository.DeleteAsync(user);
        }
    }

    public async Task<List<User>> GetUsers(int? pageNumber, int? userTypeId, DateTime? createdDate,
        bool? onlySessionsMoreTwo)
    {
        return await _usersRepository.GetUsersAsync(pageNumber, userTypeId, createdDate, onlySessionsMoreTwo);
    }
}