using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.Extensions.Caching.Distributed;
using MireaHackBack.Models.ProjectModels.Run;
using MireaHackBack.Repository;
using MireaHackBack.Services.RunCodeService.CSharp;

namespace MireaHackBack.Services.RunCodeService;

public class RunProjectService(IDistributedCache distributedCache, ILogger<RunProjectService> logger, IProjectRepository projectRepo) : IRunProjectService
{
    private readonly DockerClient _dockerClient = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();
    private readonly IDistributedCache _cache;
    private readonly ILogger<RunProjectService> _logger;
    private readonly IProjectRepository _projectRepo = projectRepo;

    public async Task<GetProjectOutputResponse> GetProjectOutput(GetProjectOutputRequest getProjectOutputRequest)
    {

    }

    public async Task<RunProjectResponse> RunProject(RunProjectRequest runProjectRequest)
    {
        var project = _projectRepo.getpro

        try
        {
            using var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();

            var container = client.Containers.CreateContainerAsync(new CreateContainerParameters()
            {
                Image=runProjectRequest.
                
            });
        }
        catch(Exception)
        {
            
        }
    }

    private async Task<string?> BuildImageFromDockerfile(string dockerfilePath, string repositoryName)
    {
        //string dockerfile = "/path/to/Dockerfile"; //unused
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

                return imageId;
            }
                
            //var containers = await client.Containers.ListContainersAsync(new ContainersListParameters());
            //string containerId = containers.FirstOrDefault()?.ID;

            //return (imageId, containerId);
        }
    
    }
    public async Task<StopProjectResponse> StopProject(StopProjectRequest stopProjectRequest)
    {
        throw new NotImplementedException();
    }
}
