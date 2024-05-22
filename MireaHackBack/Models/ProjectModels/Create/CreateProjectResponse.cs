using FileArchieveApi.Models.FileModels;

namespace MireaHackBack.Models.ProjectModels;

public class CreateProjectResponse
{
    public string ProjectName{get;set;}
    public List<FileModel> files {get;set;}
}
