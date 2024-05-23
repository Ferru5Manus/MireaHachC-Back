using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MireaHackBack.Model.Project;
using MireaHackBack.Services.RunCodeService.CSharp;

namespace MireaHackBack.Controller;

[ApiController]
[Route("[controller]")]
public class ProjectController(IRunProjectService runPrjService) : ControllerBase
{
    private readonly IRunProjectService _runPrjService = runPrjService;

    /// <summary>
    /// Создать проект
    /// </summary>
    [HttpPost]
    //[Authorize(Roles = "User")]
    [Route("createProject")]
    public async Task<IActionResult> CreateProject()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var result = await runPrjService.RunProject(new RunProjectRequest());

        return StatusCode(200, result.ProcessId);
    }   

    // /// <summary>
    // /// Редактировать данные проекта
    // /// </summary>
    // [HttpPatch]
    // [Authorize(Roles = "User")]
    // [Route("modifyProject")]
    // public IActionResult ModifyProject([FromBody] ModifyProjectRequest model)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(model);
    //     }
        
    //     throw new NotImplementedException();
    //     //var result = 
    //     //return StatusCode(result.StatusCode, result.Payload);
    // }

    // /// <summary>
    // /// Удалить проект
    // /// </summary>
    // [HttpDelete]
    // [Authorize(Roles = "User")]
    // [Route("removeProject")]
    // public IActionResult RemoveProject([FromBody] RemoveProjectRequest model)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(model);
    //     }
        
    //     throw new NotImplementedException();
    //     //var result = 
    //     //return StatusCode(result.StatusCode, result.Payload);
    // }

}