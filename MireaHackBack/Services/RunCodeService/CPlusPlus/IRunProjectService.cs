using MireaHackBack.Models.ProjectModels.Run;

namespace MireaHackBack.Services.RunCodeService.CPlusPlus;

public interface IRunProjectService
{
    Task<RunProjectResponse> RunProject(RunProjectRequest runProjectRequest);
    Task<GetProjectOutputResponse> GetProjectOutput(GetProjectOutputRequest getProjectOutputRequest);
    Task<StopProjectResponse> StopProject(StopProjectRequest stopProjectRequest);
}
