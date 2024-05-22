using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.Extensions.Caching.Distributed;
using MireaHackBack.Models.ProjectModels.Run;
using MireaHackBack.Services.RunCodeService.CSharp;

namespace MireaHackBack.Services.RunCodeService;

public class RunProjectService : IRunProjectService
{
    private DockerClient _dockerClient;
    private readonly IDistributedCache _cache;
    private readonly ILogger<RunProjectService> _logger;
    public RunProjectService(IDistributedCache distributedCache, ILogger<RunProjectService> logger)
    {
        _dockerClient =  new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();
    }
    public async Task<GetProjectOutputResponse> GetProjectOutput(GetProjectOutputRequest getProjectOutputRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<RunProjectResponse> RunProject(RunProjectRequest runProjectRequest)
    {
        throw new NotImplementedException();
        try
        {
            
        }
        catch(Exception)
        {
            
        }
    }
    private async Task BuildImageFromDockerfile(string dockerfilePath, string repositoryName)
    {
        string dockerfile = "/path/to/Dockerfile";
        string tag = repositoryName+":latest";
        
        using (var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient())
        {
          
                var imageIdStream = await client.Images.BuildImageFromDockerfileAsync(File.OpenRead(dockerfilePath), new ImageBuildParameters { Tags = new List<string> { tag } });

                using (var reader = new StreamReader(imageIdStream))
                {
                    string output = reader.ReadToEnd();
                  
                    string[] lines = output.Split("\n");
                    string? imageId = null;

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

                    /*return imageId;*/ throw new NotImplementedException();
                }
                
            
            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters());
            string containerId = containers.FirstOrDefault()?.ID;

            //return (imageId, containerId);
        }
    
    }
    public async Task<StopProjectResponse> StopProject(StopProjectRequest stopProjectRequest)
    {
        throw new NotImplementedException();
    }
}
