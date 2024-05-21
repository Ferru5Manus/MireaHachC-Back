using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.UserProfile;

public class UserProfileUpdateModel
{
    [MinLength(1)]
    [MaxLength(20)]
    public string? FirstName {get;set;}

    [MinLength(1)]
    [MaxLength(20)]
    public string? LastName {get;set;}
    
    [MinLength(1)]
    [MaxLength(100)]
    public string? About {get;set;}
}