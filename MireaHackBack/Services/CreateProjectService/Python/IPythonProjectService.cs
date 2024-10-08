using FileArchieveApi.Models.FileModels;
using MireaHackBack.Models.ProjectModels;
using MireaHackBack.Models.ProjectModels.Python;
using MireaHackBack.Models.Requests;

namespace MireaHackBack.Services.CreateProjectService.Python;

public interface IPythonProjectService
{
    Task<CreateProjectResponse> CreatePyProject(CreateProjectRequest createProjectRequest);
    Task<FileModel> AddFileToPyProject(AddPyFileRequest addFileRequest);
    Task<RemoveFileResponse> RemoveFilePyProject(RemoveFileRequest removePyFileRequest);
    Task<RemoveProjectResponse> RemovePyProject(RemoveProjectRequest removePyProjectRequest);
    Task<ModifyFilesResponse> ModifyFiles(ModifyProjectRequest modifyProjectRequest);
}
