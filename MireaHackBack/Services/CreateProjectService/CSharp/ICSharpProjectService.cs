using FileArchieveApi.Models.FileModels;
using MireaHackBack.Models.ProjectModels;
using MireaHackBack.Models.ProjectModels.CSharp;
using MireaHackBack.Models.Requests;

namespace MireaHackBack.Services.CreateProjectService.CSharp;

public interface ICSharpProjectService
{
    Task<CreateProjectResponse> CreateCSharpProject(CreateProjectRequest createProjectRequest);
    Task<FileModel> AddFileToCsProject(AddCsFileRequest addFileRequest);
    Task<RemoveFileResponse> RemoveFileCsProject(RemoveFileRequest removeCsFileRequest);
    Task<RemoveProjectResponse> RemoveCsProject(RemoveProjectRequest removeCsProjectRequest);
    Task<ModifyFilesResponse> ModifyFiles(ModifyProjectRequest modifyProjectRequest);
}
