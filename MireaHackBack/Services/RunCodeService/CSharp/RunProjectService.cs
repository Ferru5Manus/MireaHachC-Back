using System.Diagnostics;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.Extensions.Caching.Distributed;
using MireaHackBack.Model.Project;
using MireaHackBack.Response.Project;
using MireaHackBack.Services.RunCodeService.CSharp;

namespace MireaHackBack.Services.RunCodeService;

public class RunProjectService(IDistributedCache distributedCache, ILogger<RunProjectService> logger) : IRunProjectService
{
    private readonly DockerClient _dockerClient = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();
    private readonly IDistributedCache _cache;
    private readonly ILogger<RunProjectService> _logger;

    public async Task<GetProjectOutputResponse> GetProjectOutput(GetProjectOutputRequest getProjectOutputRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<RunProjectResponse> RunProject(RunProjectRequest runProjectRequest)
    {
        var result = await BuildDockerImage("Console.WriteLine(8800555)");
        return new RunProjectResponse()
        {
            IsSuccess=true,
            ProcessId=result
        };
        try
        {
            using var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();

            //var imageId = await BuildImageFromDockerfile()

            var container = client.Containers.CreateContainerAsync(new CreateContainerParameters()
            {
            //    Image=runProjectRequest.
                
            });
        }
        catch(Exception)
        {
            
        }
    }

    public async Task<string> BuildDockerImage(string csharpCode)
    {
        string content = 
        "FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env\n"+
        "WORKDIR /App\n"+

        "# Copy everything\n"+
        "COPY . ./\n"+
        "# Restore as distinct layers\n"+
        "RUN dotnet restore\n"+
        "# Build and publish a release\n"+
        "RUN dotnet publish -c Release -o out\n"+

        "# Build runtime image\n"+
        "FROM mcr.microsoft.com/dotnet/aspnet:8.0\n"+
        "WORKDIR /App\n"+
        "COPY --from=build-env /App/out .\n"+

        "EXPOSE 8080\n"+

        "ENTRYPOINT [\"dotnet\", \"AuthService.dll\"]";
        //using var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();
        //return Path.GetTempPath();

        string tempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempFolder);

        string programFilePath = Path.Combine(tempFolder, "Program.cs");
        File.WriteAllText(programFilePath, csharpCode);

        string dockerFilePath = Path.Combine(tempFolder, "Dockerfile");
        File.WriteAllText(dockerFilePath, content);
        Console.WriteLine(dockerFilePath);

        var imageIdStream = await _dockerClient.Images.BuildImageFromDockerfileAsync(File.OpenRead(dockerFilePath), new ImageBuildParameters { });
        using (var reader = new StreamReader(imageIdStream))
        {
            string output = reader.ReadToEnd();
            
            string[] lines = output.Split("\n");
            string imageId = null;
            foreach (string line in lines)
            {
                if (line.StartsWith("Successfully built"))
                {
                    imageId = line.Split(" ")[2];
                    break;
                }
            }

            if (imageId == null)
            {
                throw new Exception("Image ID not found in build output.");
            }

            return imageId;
        }
    }

    // private async Task<string?> BuildImageFromDockerfile(string dockerfilePath, string repositoryName)
    // {
    //     //string dockerfile = "/path/to/Dockerfile"; //unused
    //     string tag = repositoryName+":latest";
        
    //     using (var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient())
    //     {
    //         var imageIdStream = await client.Images.BuildImageFromDockerfileAsync(
    //             File.OpenRead(dockerfilePath), 
    //             new ImageBuildParameters 
    //             { 
                    
    //                 Tags = new List<string> { tag } 
    //             });

    //         using (var reader = new StreamReader(imageIdStream))
    //         {
    //             string output = reader.ReadToEnd();
                
    //             string[] lines = output.Split("\n");
    //             string? imageId = null;

    //             foreach (string line in lines)
    //             {
    //                 if (line.StartsWith("Successfully built"))
    //                 {
    //                     imageId = line.Split(" ")[2];
    //                     break;
    //                 }
    //             }

    //             if (imageId == null)
    //             {
    //                 throw new Exception("Image ID not found in build output.");
    //             }

    //             return imageId;
    //         }
    //     }
    // }
    public async Task<StopProjectResponse> StopProject(StopProjectRequest stopProjectRequest)
    {
        throw new NotImplementedException();
    }
}
