using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using MireaHackBack.Model.User;

namespace MireaHackBack.Controller;

[ApiController]
public class UserController : ControllerBase
{
    /// <summary>
    /// Запросить регистрацию по данному Email.
    /// </summary>
    /// <response code="200">Код отправлен на почту, если она не зарегистрирована.</response>
    [Route("register")]
    [HttpPost]
    public IActionResult Register([FromQuery] UserRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        throw new NotImplementedException();
    }   
}