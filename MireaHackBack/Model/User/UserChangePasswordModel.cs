using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.User;

public class UserChangePasswordModel
{
    [Required]
    public string OldPassword {get;set;}=null!;
    
    [Required]
    [MinLength(8)]
    [MaxLength(100)]
    public string NewPassword {get;set;}=null!;
}