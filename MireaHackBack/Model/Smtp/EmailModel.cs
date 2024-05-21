using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.Smtp;

public class EmailModel
{
    public string? Title {get;set;} = null!;

    [Required]
    public string Content {get;set;} = null!;
    
    [Required]
    [EmailAddress]
    public string To {get;set;} = null!;
}