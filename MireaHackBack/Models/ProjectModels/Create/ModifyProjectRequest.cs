using FileArchieveApi.Models.FileModels;

namespace MireaHackBack.Models.ProjectModels;

public class ModifyProjectRequest
{
    public List<FileModel> fileModels {get;set;} = null!;
    public LanguageType languageType {get;set;}
}
