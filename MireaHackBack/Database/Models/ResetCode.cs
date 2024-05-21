using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MireaHackBack.Database.Models;

[Index(nameof(UserId), IsUnique = true)]
public class ResetCode
{
    [Key]
    public long Id {get;set;}
    [Required]
    public User User {get;set;} = null!;
    [Required]
    public long UserId {get;set;}

    [Required]
    [Column(TypeName = "VARCHAR(6)")]
    public string Code {get;set;} = null!;

    [Required]
    public DateTime RetryAt {get;set;}

    [Required]
    public DateTime ValidUntil {get;set;}
}