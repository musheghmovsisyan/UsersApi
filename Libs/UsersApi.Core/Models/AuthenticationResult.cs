namespace UsersApi.Core.Models;

public class AuthenticationResult
{
    public bool Success { get; set; }

    public IEnumerable<string>? Errors { get; set; }
}