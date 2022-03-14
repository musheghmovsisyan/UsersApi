using UsersApi.Core.Models;

namespace UsersApi.Core.Contracts.Services;

public interface IAuthorizationService
{
    Task<AuthenticationResult> LoginAsync(string email, string password);
}