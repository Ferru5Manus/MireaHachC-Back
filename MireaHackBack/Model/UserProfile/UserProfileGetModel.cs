using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.UserProfile;

public class UserProfileGetModel
{
    [Required]
    public long UserId {get;set;}
}