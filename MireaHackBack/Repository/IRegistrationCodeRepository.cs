using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public interface IRegistrationCodeRepository
{
    public IQueryable<RegistrationCode> GetRegistrationCodes();
    public RegistrationCode? GetRegistrationCodeById(int id);
    public RegistrationCode? GetRegistrationCodeByEmail(string email);
    public RegistrationCode? GetRegistrationCodeByCode(string code);
    public bool CreateRegistrationCode(RegistrationCode regcode);
    public bool UpdateRegistrationCode(RegistrationCode regcode);
    public bool DeleteRegistrationCode(RegistrationCode regcode);
    public bool Save();
}