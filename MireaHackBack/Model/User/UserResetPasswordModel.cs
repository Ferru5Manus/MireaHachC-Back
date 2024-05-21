using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.User;

public class UserResetPasswordModel
{
    [Required]
    public string Email {get;set;} = null!;
    [Required]
    public string ResetCode {get;set;} = null!;
    [Required]
    [MinLength(8)]
    [MaxLength(100)]
    public string NewPassword {get;set;} = null!;
}