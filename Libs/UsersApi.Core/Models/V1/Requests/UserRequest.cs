using System.ComponentModel.DataAnnotations;

namespace UsersApi.Core.Models.V1.Requests;

public class UserRequest
{
    [Required]
    [StringLength(256)] 
    public string UserName { get; set; } = null!;

    [Required] 
    [StringLength(256)] 
    public string FullName { get; set; } = null!;

    [Required] 
    [EmailAddress] 
    public string Email { get; set; } = null!;

    [Required] 
    public string Password { get; set; } = null!;

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public int UserTypeId { get; set; }
}