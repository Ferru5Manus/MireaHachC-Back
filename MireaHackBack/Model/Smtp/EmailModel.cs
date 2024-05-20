using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Model.Smtp;

public class EmailModel
{
    public string Title {get;set;}
    [Required]
    public string Content {get;set;}
    [Required]
    [EmailAddress]
    public string To {get;set;}
}