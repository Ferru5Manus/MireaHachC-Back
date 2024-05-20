using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.User;

public class UserFinishRegistrationModel
{
    private string _firstName;
    private string _lastName;
    private string _username;

    [Required]
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value?.Trim(); }
    }

    [Required]
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value?.Trim(); }
    }

    [Required]
    public string Username
    {
        get { return _username; }
        set { _username = value?.Trim(); }
    }

    [Required]
    public string RegistrationCode {get;set;}
}