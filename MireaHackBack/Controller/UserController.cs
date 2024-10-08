using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MireaHackBack.Model.User;
using MireaHackBack.Response.User;
using MireaHackBack.Services;

namespace MireaHackBack.Controller;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Запросить регистрацию по данному Email
    /// </summary>
    /// <response code="200">Код отправлен на почту.</response>
    /// <response code="409">Аккаунт с данной электронной почтой существует.</response>
    /// <response code="429">Письмо уже было запрошено менее минуты назад.</response>
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
    /// <response code="401">Некорректная электронная почта или код регистрации, либо действие кода регистрации истекло.</response>
    [Route("finishRegistration")]
    [HttpPost]
    public IActionResult FinishRegistration([FromQuery] UserFinishRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }
        
        var result = _userService.FinishRegistration(model);
        return StatusCode(result.StatusCode, result.Payload);
    }

    /// <summary>
    /// Войти в аккаунт
    /// </summary>
    /// <response code="200">Вход успешен.</response>
    /// <response code="401">Неверное имя пользователя или пароль.</response>
    [ProducesResponseType(typeof(TokenResponse), (int)HttpStatusCode.OK), ]
    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromQuery] UserLoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }
        
        var result = _userService.Login(model);
        return StatusCode(result.StatusCode, result.Payload);
    }

    /// <summary>
    /// Изменить пароль аккаунта
    /// </summary>
    /// <response code="200">Успешно, выдан новый токен.</response>
    /// <response code="401">Вы не авторизованы, либо был передан некорректный старый пароль.</response>
    [ProducesResponseType(typeof(TokenResponse), (int)HttpStatusCode.OK), ]
    [Route("changePassword")]
    [HttpPost]
    [Authorize(Roles = "User")]
    public IActionResult ChangePassword([FromQuery] UserChangePasswordModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var result = _userService.ChangePassword(User, model);
        return StatusCode(result.StatusCode, result.Payload);
    }

    /// <summary>
    /// Получить обновленный токен доступа.
    /// </summary>
    /// <response code="200">Успешно.</response>
    /// <response code="401">Токен не прошел валидацию.</response>
    [ProducesResponseType(typeof(TokenResponse), (int)HttpStatusCode.OK), ]
    [Route("updateToken")]
    [HttpPost]
    [Authorize(Roles = "User")]
    public IActionResult UpdateToken()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var result = _userService.UpdateToken(User);
        return StatusCode(result.StatusCode, result.Payload);
    }

    /// <summary>
    /// Запросить сброс пароля
    /// </summary>
    /// <response code="200">Код отправлен на почту.</response>
    /// <response code="404">Пользователь не найден.</response>
    [Route("requestPasswordReset")]
    [HttpPost]
    public IActionResult RequestPasswordReset([FromQuery] UserRequestPasswordResetModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }
        
        var result = _userService.RequestPasswordReset(model);
        return StatusCode(result.StatusCode, result.Payload);
    }

    /// <summary>
    /// Сбросить пароль, используя код
    /// </summary>
    /// <response code="200">Пароль успешно сброшен.</response>
    /// <response code="401">Некорректный код или почта, либо действие кода истекло.</response>
    [Route("resetPassword")]
    [HttpPost]
    public IActionResult ResetPassword([FromQuery] UserResetPasswordModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }
        
        var result = _userService.ResetPassword(model);
        return StatusCode(result.StatusCode, result.Payload);
    }
}