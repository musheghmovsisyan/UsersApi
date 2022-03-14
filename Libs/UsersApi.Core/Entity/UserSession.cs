using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApi.Core.Entity;

public class UserSession
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = null!;

    [Required] 
    public string JwtId { get; set; } = null!;

    [Required] 
    public DateTime CreationDate { get; set; }

    [Required] 
    public DateTime ExpiryDate { get; set; }

    [Required] 
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))] 
    public User User { get; set; } = null!;
}