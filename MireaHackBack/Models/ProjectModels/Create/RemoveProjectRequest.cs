namespace MireaHackBack.Models.ProjectModels;

public class RemoveProjectRequest
{
    public LanguageType languageType {get;set;}
    public string projectPath {get;set;} = null!;
}
