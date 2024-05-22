using System.Diagnostics;
using FileArchieveApi.Models.FileModels;
using FileArchieveApi.Singletones.Files;
using MireaHackBack.Exceptions.CreateProjectExceptions.CSharp;
using MireaHackBack.Models.ProjectModels;
using MireaHackBack.Models.ProjectModels.CSharp;
using MireaHackBack.Models.Requests;
using MireaHackBack.Services.CreateProjectService.CSharp;

namespace MireaHackBack.Services.CreateCSharpProjectService.CSharp;

public class CSharpProjectService : ICSharpProjectService
{
    private readonly FileAccesor _fileAccesor; 
    private readonly ILogger<CSharpProjectService> _logger; 
    public CSharpProjectService(FileAccesor fileAccesor, ILogger<CSharpProjectService> logger)
    {
        _fileAccesor = fileAccesor;
        _logger = logger;
    }
    
    public async Task<FileModel?> AddFileToCsProject(AddCsFileRequest addFileRequest)
    {
        try
        {
            switch (addFileRequest.fileType)
            {
                case FileType.CLASS:
                    return _fileAccesor.CreateFile(@"
                    public class MyClass
                    {
                        
                    }  
                    ",addFileRequest.filePath);
                  
                case FileType.ENUM:
                    return _fileAccesor.CreateFile(@"
                    public enum MyEnumType
                    {
                        
                    } 
                    ",addFileRequest.filePath);
                case FileType.INTERFACE:
                    return _fileAccesor.CreateFile(@"
                    public interfale IMyInterface
                    {
                        
                    } 
                    ",addFileRequest.filePath);
                default:
                    return null;
            }
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
    public async Task<CreateProjectResponse> CreateCSharpProject(CreateProjectRequest createProjectRequest)
    {
        try
        {
            string projectName = createProjectRequest.projectName;
            string command = $"dotnet new console -n {projectName}";
            List<FileModel> files = await RunDotnetCommand(command,createProjectRequest);
            
            _logger.LogInformation("Project created!");
            return new CreateProjectResponse(){ files = files, ProjectName = createProjectRequest.projectName};
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            if(ex is CreateCsProjectCommandException)
            {
                throw;
            }
            throw new CreateCsProjectException(ex.Message);
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
            throw;
        }
    }

    public async Task<RemoveProjectResponse> RemoveCsProject(RemoveProjectRequest removeCsProjectRequest)
    {
       try
       {
            _fileAccesor.RemoveProject(removeCsProjectRequest.projectPath);
            return new RemoveProjectResponse(){ IsSuccess = true};
       }
       catch(Exception ex)
       {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<RemoveFileResponse> RemoveFileCsProject(RemoveFileRequest removeCsFileRequest)
    {
        try
        {
            _fileAccesor.RemoveFile(removeCsFileRequest.filePath);
            return new RemoveFileResponse(){ IsSuccess = true};
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    private async Task<List<FileModel>> RunDotnetCommand(string arguments, CreateProjectRequest createProjectRequest)
    {
        try
        {
            //TODO add caching 
            Process process = new();
            process.StartInfo.FileName = "dotnet";
            process.StartInfo.Arguments = arguments;
            process.StartInfo.WorkingDirectory = "/root/NestedProjects/"+createProjectRequest.userName+"/"+createProjectRequest.projectName;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
            _fileAccesor.CreateFile(@"
        
            FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
            WORKDIR /app

            # Copy csproj and restore as distinct layers
            COPY *.csproj ./
            RUN dotnet restore

            # Copy the remaining source code
            COPY . ./
            RUN dotnet publish -c Release -o out

            # Build runtime image
            FROM mcr.microsoft.com/dotnet/runtime:5.0
            WORKDIR /app
            COPY --from=build /app/out .
            ENTRYPOINT ["+"dotnet"+", "+createProjectRequest.projectName+"]"
            ,"/root/NestedProjects/"+createProjectRequest.userName+"/"+createProjectRequest.projectName);

            return _fileAccesor.GetFiles("/root/NestedProjects/"+createProjectRequest.userName+"/"+createProjectRequest.projectName);
        }
        catch(Exception ex)
        {
            throw new CreateCsProjectCommandException(ex.Message);
        }

   
    }
}
