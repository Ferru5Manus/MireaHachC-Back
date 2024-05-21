using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.Smtp;

public class EmailModel
{
    public string? Subject {get;set;} = null!;

    [Required]
    public string Body {get;set;} = null!;
    
    [Required]
    [EmailAddress]
    public string To {get;set;} = null!;
}