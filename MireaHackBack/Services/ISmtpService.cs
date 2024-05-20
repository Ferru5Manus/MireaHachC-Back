using MireaHackBack.Model.Smtp;

namespace MireaHackBack.Services;

public interface ISmtpService
{
    public Task<bool> SendSystemMail(EmailModel model);
}