using UsersApi.Core.Entity;

namespace UsersApi.Core.Models.V1.Responses;

public class UserResponse
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public UserType UserType { get; set; } = null!;
}