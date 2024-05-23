using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MireaHackBack.Model.User;
using MireaHackBack.Model.UserProfile;
using MireaHackBack.Response;
using MireaHackBack.Response.User;
using MireaHackBack.Services;

namespace MireaHackBack.Controller;

[ApiController]
[Route("[controller]")]
public class UserProfileController(IUserProfileService userProfileService) : ControllerBase
{
    private readonly IUserProfileService _userProfileService = userProfileService;

    /// <summary>
    /// Полуить профиль по id пользователя
    /// </summary>
    /// <response code="200"></response>
    /// <response code="404">Профиль не найден.</response>
    [HttpGet]
    [Route("get")]
    [ProducesResponseType(typeof(UserProfileResponse), (int)HttpStatusCode.OK)]
    public IActionResult Get([FromQuery] UserProfileGetModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        var result = _userProfileService.Get(model);
        return StatusCode(result.StatusCode, result.Payload);
    }

    /// <summary>
    /// Обновить данные профиля
    /// </summary>
    /// <response code="200"></response>
    /// <response code="404">Профиль не найден.</response>
    [Route("update")]
    [HttpPatch]
    [Authorize(Roles = "User")]
    [ProducesResponseType(typeof(UserProfileResponse), (int)HttpStatusCode.OK)]
    public IActionResult Update(UserProfileUpdateModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        var result = _userProfileService.Update(User, model);
        return StatusCode(result.StatusCode, result.Payload);
    }
}