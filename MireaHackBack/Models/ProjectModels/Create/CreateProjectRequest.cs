using System.ComponentModel.DataAnnotations;
using MireaHackBack.Models.ProjectModels;

namespace MireaHackBack.Models.Requests;

public class CreateProjectRequest
{
    [Required]
    public string projectName {get;set;}
    [Required]
    public LanguageType languageType {get;set;}
    public string? userName{get;set;}
}
