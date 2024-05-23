using System.Security.Claims;
using MireaHackBack.Model.UserProfile;
using MireaHackBack.Response;

namespace MireaHackBack.Services;

public interface IUserProfileService
{
    public ApiResponse Get(UserProfileGetModel model);
    public ApiResponse Update(ClaimsPrincipal userClaims, UserProfileUpdateModel model);
}