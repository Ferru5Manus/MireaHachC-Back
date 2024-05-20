using MireaHackBack.Model.User;
using MireaHackBack.Response;

namespace MireaHackBack.Services;

public interface IUserService
{
    public ApiResponse Register(UserRegistrationModel model);
    public ApiResponse FinishRegistration(UserFinishRegistrationModel model);
}