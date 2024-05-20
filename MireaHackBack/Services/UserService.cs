using MireaHackBack.Model.User;
using MireaHackBack.Repository;
using MireaHackBack.Response;

namespace MireaHackBack.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IUserProfileRepository _userProfileRepo;
    private readonly ISmtpService _smtp;

    public UserService(IUserRepository userRepo, IUserProfileRepository userProfileRepo, ISmtpService smtp)
    {
        _userRepo = userRepo;
        _userProfileRepo = userProfileRepo;
        _smtp = smtp;
    }
    public ApiResponse FinishRegistration(UserFinishRegistrationModel model)
    {
        throw new NotImplementedException();
    }

    public ApiResponse Register(UserRegistrationModel model)
    {
        throw new NotImplementedException();
    }
}