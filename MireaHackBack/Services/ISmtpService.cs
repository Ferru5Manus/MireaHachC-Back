using MireaHackBack.Model.Smtp;

namespace MireaHackBack.Services;

public interface ISmtpService
{
    public bool SendSystemMail(EmailModel model);
}