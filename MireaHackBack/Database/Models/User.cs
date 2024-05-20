using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MireaHackBack.Database.Models;

public class User
{
    [Key]
    public int Id {get;set;}
    [Required]
    [MinLength(3)]
    [Column(TypeName = "VARCHAR(20)")]
    public string Username {get;set;}
    [Required]
    [EmailAddress]
    public string Email {get;set;}
    [Required]
    [MinLength(8)]
    [Column(TypeName = "VARCHAR(50)")]
    public string Password {get;set;}
    [Required]
    public DateTime PasswordChangeDate {get;set;}
    [Required]
    public DateTime RegistrationDate {get;set;}
}