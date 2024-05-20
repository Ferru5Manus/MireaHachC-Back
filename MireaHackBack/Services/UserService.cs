using System.Security.Claims;
using MireaHackBack.Database.Models;
using MireaHackBack.Model.Smtp;
using MireaHackBack.Model.User;
using MireaHackBack.Repository;
using MireaHackBack.Response;
using MireaHackBack.Response.General;
using MireaHackBack.Response.User;
using MireaHackBack.Utils;

namespace MireaHackBack.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IUserProfileRepository _userProfileRepo;
    private readonly IRegistrationCodeRepository _regcodeRepo;
    private readonly ISmtpService _smtp;
    private readonly Jwt _jwt;

    public UserService(IUserRepository userRepo, IUserProfileRepository userProfileRepo, IRegistrationCodeRepository regcodeRepo, ISmtpService smtp)
    {
        _userRepo = userRepo;
        _userProfileRepo = userProfileRepo;
        _regcodeRepo = regcodeRepo;
        _smtp = smtp;
        _jwt = new Jwt();
    }
    public ApiResponse FinishRegistration(UserFinishRegistrationModel model)
    {
        var regcode = _regcodeRepo.GetRegistrationCodeByEmail(model.Email);
        if (regcode == null || regcode.Code != model.RegistrationCode)
        {
            return new ApiResponse{StatusCode=401, Payload=new MessageResponse{Message="Invalid email or registration code"}};
        }

        if (regcode.ValidUntil < DateTime.UtcNow)
        {
            return new ApiResponse{StatusCode=401, Payload=new MessageResponse{Message="Registration Code seems to be expired"}};
        }

        var newUser = new User 
        {
            Email=regcode.Email,
            Username=model.Username,
            Password=BcryptUtils.HashPassword(model.Password),
            PasswordChangeDate=DateTime.UtcNow,
            RegistrationDate=DateTime.UtcNow
        };
        _userRepo.CreateUser(newUser);

        var newUserProfile = new UserProfile
        {
            User = newUser,
            FirstName=model.FirstName,
            LastName=model.LastName
        };
        _userProfileRepo.CreateUserProfile(newUserProfile);
        _regcodeRepo.DeleteRegistrationCode(regcode);

        return new ApiResponse{StatusCode=200, Payload=new MessageResponse{Message="Successfully finished registration"}};
    }

    public string GrantJwtToken(User user)
    {
        var claims = new List<Claim>
        {

            new(ClaimsIdentity.DefaultNameClaimType, user.Username),
            new(ClaimsIdentity.DefaultRoleClaimType,"User")
        };
        
        return _jwt.GrantToken(claims, DateTime.UtcNow.AddDays(1));
    }

    public ApiResponse Login(UserLoginModel model)
    {
        var user = _userRepo.GetUserByUsername(model.Username);

        if (user == null || !BcryptUtils.VerifyPassword(model.Password, user.Password))
        {
            return new ApiResponse{StatusCode=401, Payload=new MessageResponse{Message="Invalid username or password"}};
        }

        var response = new TokenResponse{
            Token=GrantJwtToken(user)
        };

        return new ApiResponse{StatusCode=200, Payload=response};
    }

    public ApiResponse Register(UserRegistrationModel model)
    {
        if (_userRepo.GetUserByEmail(model.Email)!=null)
        {
            return new ApiResponse{StatusCode=409, Payload=new MessageResponse{Message="Email already registered"}};
        }

        var existingCode = _regcodeRepo.GetRegistrationCodeByEmail(model.Email);
        if (existingCode != null)
        {
            if (DateTime.UtcNow > existingCode.RetryAt || DateTime.UtcNow > existingCode.ValidUntil)
            {
                _regcodeRepo.DeleteRegistrationCode(existingCode);
            }
            else
            {
                return new ApiResponse{StatusCode=429, Payload=new MessageResponse{Message="Wait 2 minutes to request another code"}};
            }
        }

        var regcodeString = CodeGenerator.CodeGen(6);

        RegistrationCode regcode = new()
        {
            Email=model.Email,
            Code=regcodeString,
            ValidUntil=DateTime.UtcNow.AddHours(2),
            RetryAt=DateTime.UtcNow.AddMinutes(2)
        };
        _regcodeRepo.CreateRegistrationCode(regcode);

        try
            {
            _smtp.SendSystemMail(new EmailModel{
                Title="Registration Code",
                Content=$"Your registration code is {regcodeString}",
                To=model.Email
            });
        }
        catch (Exception)
        {
            _regcodeRepo.DeleteRegistrationCode(regcode);
            return new ApiResponse{StatusCode=500, Payload=new MessageResponse{Message="Failed to send email."}};
        }

        return new ApiResponse{StatusCode=200, Payload=new MessageResponse{Message="Code sent to email"}};
    }
}