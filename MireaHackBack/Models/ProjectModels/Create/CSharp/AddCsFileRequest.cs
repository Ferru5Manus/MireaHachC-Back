namespace MireaHackBack.Models.ProjectModels.CSharp;

public class AddCsFileRequest
{
    public string fileName {get;set;} = null!;
    public string filePath {get;set;} = null!;
    public FileType fileType {get;set;}
}
