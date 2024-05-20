using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using MireaHackBack.Model.User;
using MireaHackBack.Services;

namespace MireaHackBack.Controller;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Запросить регистрацию по данному Email.
    /// </summary>
    /// <response code="200">Код отправлен на почту.</response>
    [Route("register")]
    [HttpPost]
    public IActionResult Register([FromQuery] UserRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }
        
        var result = _userService.Register(model);
        return StatusCode(result.StatusCode, result.Payload);
    }   

    /// <summary>
    /// Завершить регистрацию аккаунта
    /// </summary>
    /// <response code="200">Аккаунт зарегистрирован.</response>
    [Route("finishRegistration")]
    [HttpPost]
    public IActionResult Register([FromQuery] UserFinishRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }
        
        var result = _userService.FinishRegistration(model);
        return StatusCode(result.StatusCode, result.Payload);
    }   
}