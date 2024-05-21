using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.User;

public class UserLoginModel
{
    [Required]
    public string Username {get;set;} = null!;
    
    [Required]
    public string Password {get;set;} = null!;
}