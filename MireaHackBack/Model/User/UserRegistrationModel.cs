using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.User;

public class UserRegistrationModel
{
    [Required]
    [EmailAddress]
    public string Email {get;set;}
}