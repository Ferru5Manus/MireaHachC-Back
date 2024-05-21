using FileArchieveApi.Models.FileModels;

namespace MireaHackBack.Models.ProjectModels;

public class ModifyProjectRequest
{
    public List<FileModel> fileModels {get;set;}
    public LanguageType languageType {get;set;}
}
