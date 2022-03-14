using System.ComponentModel.DataAnnotations;

namespace UsersApi.Core.Models.V1.Requests;

public class UserLoginRequest
{
    [Required] 
    public string Username { get; set; } = null!;

    [Required] 
    public string Password { get; set; } = null!;
}