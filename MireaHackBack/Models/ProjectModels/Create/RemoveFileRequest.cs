namespace MireaHackBack.Models.ProjectModels;

public class RemoveFileRequest
{
    public string filePath {get;set;} = null!;
    public LanguageType languageType {get;set;}
}
