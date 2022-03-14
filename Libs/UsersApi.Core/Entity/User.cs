using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApi.Core.Entity;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = null!;

    [Required] [StringLength(256)] 
    public string UserName { get; set; } = null!;

    [Required] [StringLength(256)]
    public string FullName { get; set; } = null!;

    [Required] 
    public string Email { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedDate { get; init; } = DateTime.UtcNow;

    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

    [Required] 
    public bool IsActive { get; set; } = true;

    public string NormalizedEmail { get; set; } = null!;

    public string NormalizedUserName { get; set; } = null!;

    [Required]
    public int UserTypeId { get; set; }

    [ForeignKey(nameof(UserTypeId))] 
    public UserType UserType { get; set; } = null!;

    public IList<UserSession>? UserSessions { get; set; }
}