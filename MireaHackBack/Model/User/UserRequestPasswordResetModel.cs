using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.User;

public class UserRequestPasswordResetModel
{
    [Required]
    public string Email {get;set;} = null!;
}