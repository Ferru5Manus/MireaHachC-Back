using FileArchieveApi.Models.FileModels;

namespace MireaHackBack.Models.ProjectModels;

public class CreateProjectResponse
{
    public string ProjectName{get;set;} = null!;
    public List<FileModel> files {get;set;} = null!;
}
