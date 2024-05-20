using MireaHackBack.Model.Smtp;

namespace MireaHackBack.Services;

public class SmtpService : ISmtpService
{
    private readonly ISmtpService _smtp;

    public SmtpService(ISmtpService smtp)
    {
        _smtp = smtp;
    }
    public async Task<bool> SendSystemMail(EmailModel model)
    {
        throw new NotImplementedException();
    }
}