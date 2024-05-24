namespace MireaHackBack.Models.ProjectModels.NodeJs;

public class AddNodeFileRequest
{
    public string fileName {get;set;} = null!;
    public string filePath {get;set;} = null!;
    public FileType fileType {get;set;}
}
