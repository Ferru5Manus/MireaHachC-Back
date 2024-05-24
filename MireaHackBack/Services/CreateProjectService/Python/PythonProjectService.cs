using System.Diagnostics;
using FileArchieveApi.Models.FileModels;
using FileArchieveApi.Singletones.Files;
using MireaHackBack.Models.ProjectModels;
using MireaHackBack.Models.ProjectModels.Python;
using MireaHackBack.Models.Requests;

namespace MireaHackBack.Services.CreateProjectService.Python;

public class PythonProjectService(FileAccesor fileAccesor, ILogger<IPythonProjectService> logger) : IPythonProjectService
{
    private readonly FileAccesor _fileAccesor = fileAccesor; 
    private readonly ILogger<IPythonProjectService> _logger = logger; 
    public async Task<FileModel> AddFileToPyProject(AddPyFileRequest addFileRequest)
    {
        try
        {
            switch (addFileRequest.fileType)
            {
                case FileType.MAIN:
                    return _fileAccesor.CreateFile(@"
                    def main():
                        pass

                    if __name__ == '__main__':
                        main()
                    ",addFileRequest.filePath);
                  
                case FileType.EMPTY:
                    return _fileAccesor.CreateFile(@"
                    
                    ",addFileRequest.filePath);
                default:
                    return null;
            }
            
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            throw ex;
        }
    }

    public async Task<CreateProjectResponse> CreatePyroject(CreateProjectRequest createProjectRequest)
    {
        try
        {
            string projectName = createProjectRequest.projectName;
            string command = $"dotnet new console -n {projectName}";
            List<FileModel> files = await RunPythonCommand(command,createProjectRequest);
            
            _logger.LogInformation("Project created!");
            return new CreateProjectResponse(){ files = files, ProjectName = createProjectRequest.projectName};
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
            // if(ex is CreateCsProjectCommandException)
            // {
            //     throw ex;
            // }
            // throw new CreateCsProjectException(ex.Message);
        }
    }

    public async Task<ModifyFilesResponse> ModifyFiles(ModifyProjectRequest modifyProjectRequest)
    {
        try
        {
            _fileAccesor.ModifyFiles(modifyProjectRequest.fileModels);
            return new ModifyFilesResponse(){IsSuccess = true};
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            throw ex;
        }
    }

    public async Task<RemoveFileResponse> RemoveFilePyProject(RemoveFileRequest removePyFileRequest)
    {
        try
        {
            _fileAccesor.RemoveFile(removePyFileRequest.filePath);
            return new RemoveFileResponse(){ IsSuccess = true};
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            throw ex;
        }
    }

    public async Task<RemoveProjectResponse> RemovePyProject(RemoveProjectRequest removePyProjectRequest)
    {
        try
       {
            _fileAccesor.RemoveProject(removePyProjectRequest.projectPath);
            return new RemoveProjectResponse(){ IsSuccess = true};
       }
       catch(Exception ex)
       {
            _logger.LogError(ex.Message);
            throw ex;
       }
    }

    private async Task<List<FileModel>> RunPythonCommand(string arguments, CreateProjectRequest createProjectRequest)
    {
        try
        {
            //TODO add caching 
            _fileAccesor.CreateFile(@"
        
            # Use an official Python runtime as a parent image
            FROM python:3.8-slim

            # Set the working directory in the container
            WORKDIR /app

            # Copy the current directory contents into the container at /app
            COPY . /app

            # Set the entrypoint to run the Python script\n"
            +"ENTRYPOINT [\"python\", \"__main__.py\"]"                

            ,$"{Environment.GetEnvironmentVariable("NEST_PROJ_PATH")}"+createProjectRequest.userName+"/"+createProjectRequest.projectName);

            return _fileAccesor.GetFiles($"{Environment.GetEnvironmentVariable("NEST_PROJ_PATH")}"+createProjectRequest.userName+"/"+createProjectRequest.projectName);
        }
        catch(Exception)
        {
            throw;
        }
    }
}