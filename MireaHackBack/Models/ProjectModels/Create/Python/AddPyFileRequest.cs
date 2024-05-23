namespace MireaHackBack.Models.ProjectModels.Python;

public class AddPyFileRequest
{
    public string fileName {get;set;} = null!;
    public string filePath {get;set;} = null!;
    public FileType fileType {get;set;}
}
