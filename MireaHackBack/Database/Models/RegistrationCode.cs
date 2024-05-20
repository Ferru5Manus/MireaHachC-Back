using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MireaHackBack.Database.Models;

public class RegistrationCode
{
    [Key]
    public long Id {get;set;}

    [Required]
    [EmailAddress]
    public string Email {get;set;}

    [Required]
    [Column(TypeName = "VARCHAR(6)")]
    public string Code {get;set;}

    [Required]
    public DateTime RetryAt {get;set;}

    [Required]
    public DateTime ValidUntil {get;set;}
}