using UsersApi.Core.Contracts.Common;
using UsersApi.Core.Contracts.Repositories;
using UsersApi.Core.Contracts.Services;
using UsersApi.Core.Entity;
using UsersApi.Core.Models;

namespace UsersApi.Core.Application.Services;

internal class AuthorizationService : IAuthorizationService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUserSessionRepository _sessionRepository;

    public AuthorizationService(IUsersRepository usersRepository, IUserSessionRepository sessionRepository)
    {
        _usersRepository = usersRepository;
        _sessionRepository = sessionRepository;
    }

    public async Task<AuthenticationResult> LoginAsync(string userNameOrEmail, string password)
    {
        var user = await _usersRepository.FindUserByUserNameOrEmailAsync(userNameOrEmail);

        if (user is not null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            await _sessionRepository.AddAsync(new UserSession
            {
                JwtId = Guid.NewGuid().ToString(),
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddHours(Defines.Expiry),
                UserId = user.Id
            });

            return new AuthenticationResult {Success = true};
        }

        return new AuthenticationResult
            {Errors = new List<string> {"Your username and password do not match. Please try again."}};
    }
}