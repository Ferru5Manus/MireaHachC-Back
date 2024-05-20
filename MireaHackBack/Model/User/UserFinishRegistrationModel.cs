using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.User;

public class UserFinishRegistrationModel
{
    private string _firstName = null!;
    private string _lastName = null!;
    private string _username = null!;

    [Required]
    public string Email {get;set;} = null!;
    [Required]
    [MinLength(8)]
    [MaxLength(100)]
    public string Password {get;set;} = null!;

    [Required]
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value.Trim(); }
    }

    [Required]
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value.Trim(); }
    }

    [Required]
    public string Username
    {
        get { return _username; }
        set { _username = value.Trim(); }
    }

    [Required]
    public string RegistrationCode {get;set;} = null!;
}