using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MireaHackBack.Database.Models;

public class ResetCode
{
    [Key]
    long Id {get;set;}

    [Required]
    User User {get;set;} = null!;

    [Required]
    [Column(TypeName = "VARCHAR(6)")]
    string Code {get;set;} = null!;

    [Required]
    public DateTime RetryAt {get;set;}

    [Required]
    public DateTime ValidUntil {get;set;}
}