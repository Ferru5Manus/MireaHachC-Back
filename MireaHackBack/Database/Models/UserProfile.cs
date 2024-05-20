using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MireaHackBack.Database.Models;

public class UserProfile
{
    [Key]
    public long Id {get;set;}
    [Required]
    public User User {get;set;} = null!;

    [Required]
    [MinLength(1)]
    [MaxLength(20)]
    [Column(TypeName = "VARCHAR(20)")]
    public string FirstName {get;set;} = null!;
    [Required]
    [MinLength(1)]
    [MaxLength(20)]
    [Column(TypeName = "VARCHAR(20)")]
    public string LastName {get;set;} = null!;
    [MaxLength(100)]
    [Column(TypeName = "VARCHAR(100)")]
    public string? About {get;set;}
    public string? Picture {get;set;}
}