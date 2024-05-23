using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MireaHackBack.Database.Models;

[Index(nameof(Email), IsUnique = true)]
public class RegistrationCode
{
    [Key]
    public long Id {get;set;}

    [Required]
    [EmailAddress]
    public string Email {get;set;} = null!;

    [Required]
    [Column(TypeName = "VARCHAR(6)")]
    public string Code {get;set;} = null!;

    [Required]
    public DateTime RetryAt {get;set;}

    [Required]
    public DateTime ValidUntil {get;set;}
}