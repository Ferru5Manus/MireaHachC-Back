using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MireaHackBack.Database.Models;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public long Id {get;set;}
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    [Column(TypeName = "VARCHAR(20)")]
    public string Username {get;set;} = null!;
    [Required]
    [EmailAddress]
    public string Email {get;set;} = null!;
    [Required]
    public string Password {get;set;} = null!;
    [Required]
    public DateTime PasswordChangeDate {get;set;}
    [Required]
    public DateTime RegistrationDate {get;set;}
}