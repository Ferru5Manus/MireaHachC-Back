namespace MireaHackBack.Response;

public class UserProfileResponse
{
    public required long UserId { get; set; }
    public required string FirstName {get;set;}
    public required string LastName {get;set;}
    public string? About {get;set;}
    public string? Picture {get;set;}
}