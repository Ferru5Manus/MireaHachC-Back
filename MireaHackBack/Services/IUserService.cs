using System.Security.Claims;
using MireaHackBack.Database.Models;
using MireaHackBack.Model.User;
using MireaHackBack.Response;

namespace MireaHackBack.Services;

public interface IUserService
{
    public string GrantJwtToken(User user);
    public ApiResponse Register(UserRegistrationModel model);
    public ApiResponse FinishRegistration(UserFinishRegistrationModel model);
    public ApiResponse Login(UserLoginModel model);
    public ApiResponse RequestPasswordReset(UserRequestPasswordResetModel model);
    public ApiResponse ResetPassword(UserResetPasswordModel model);
    public ApiResponse UpdateToken(ClaimsPrincipal userClaims);
    public ApiResponse ChangePassword(ClaimsPrincipal userClaims, UserChangePasswordModel model);
}