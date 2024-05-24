using FileArchieveApi.Models.FileModels;
using MireaHackBack.Models.ProjectModels;
using MireaHackBack.Models.ProjectModels.NodeJs;
using MireaHackBack.Models.Requests;

namespace MireaHackBack.Services.CreateProjectService.NodeJs;

public interface INodeJsProjectService
{
    Task<CreateProjectResponse> CreateNodeProject(CreateProjectRequest createProjectRequest);
    Task<FileModel> AddFileToNodeProject(AddNodeFileRequest addFileRequest);
    Task<RemoveFileResponse> RemoveFileNodeProject(RemoveFileRequest removeNodeFileRequest);
    Task<RemoveProjectResponse> RemoveNodeProject(RemoveProjectRequest removeNodeProjectRequest);
    Task<ModifyFilesResponse> ModifyFiles(ModifyProjectRequest modifyProjectRequest);
}
