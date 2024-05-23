using System.Security.Claims;
using MireaHackBack.Model.UserProfile;
using MireaHackBack.Repository;
using MireaHackBack.Response;
using MireaHackBack.Response.General;

namespace MireaHackBack.Services;

public class UserProfileService(IUserProfileRepository userProfileRepo, IUserService userService) : IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepo = userProfileRepo;
    private readonly IUserService _userService = userService;

    public ApiResponse Get(UserProfileGetModel model)
    {
        var profile = _userProfileRepo.GetUserProfileByUserId(model.UserId);
        if (profile == null)
        {
            return new ApiResponse{StatusCode=404};
        }

        return new ApiResponse
        {
            StatusCode=200,
            Payload=new UserProfileResponse
            {
                UserId=profile.UserId,
                FirstName=profile.FirstName,
                LastName=profile.LastName,
                About=profile.About,
                Picture=profile.Picture
            }
        };
    }

    public ApiResponse Update(ClaimsPrincipal userClaims, UserProfileUpdateModel model)
    {
        if (!_userService.ValidateToken(userClaims, out string username))
        {
            return new ApiResponse{StatusCode=401};
        }

        var profile = _userProfileRepo.GetUserProfileByUsername(username);
        
        if (profile == null)
        {
            return new ApiResponse{StatusCode=404};
        }

        profile.FirstName = model.FirstName ?? profile.FirstName;
        profile.LastName = model.LastName ?? profile.LastName;
        profile.About = model.About ?? profile.About;

        _userProfileRepo.UpdateUserProfile(profile);

        return new ApiResponse
        {
            StatusCode=200,
            Payload=new UserProfileResponse
            {
                UserId=profile.UserId,
                FirstName=profile.FirstName,
                LastName=profile.LastName,
                About=profile.About,
                Picture=profile.Picture
            }
        };
    }
}