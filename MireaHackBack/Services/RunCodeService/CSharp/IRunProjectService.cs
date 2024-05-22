using MireaHackBack.Model.Project;
using MireaHackBack.Response.Project;

namespace MireaHackBack.Services.RunCodeService.CSharp;

public interface IRunProjectService
{
    Task<RunProjectResponse> RunProject(RunProjectRequest runProjectRequest);
    Task<GetProjectOutputResponse> GetProjectOutput(GetProjectOutputRequest getProjectOutputRequest);
    Task<StopProjectResponse> StopProject(StopProjectRequest stopProjectRequest);
}
