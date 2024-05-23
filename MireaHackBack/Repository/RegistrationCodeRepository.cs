using MireaHackBack.Database;
using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public class RegistrationCodeRepository(ApplicationContext db) : IRegistrationCodeRepository
{
    private readonly ApplicationContext _db = db;

    public bool CreateRegistrationCode(RegistrationCode regcode)
    {
        _db.RegistrationCodes.Add(regcode);
        return Save();
    }

    public bool DeleteRegistrationCode(RegistrationCode regcode)
    {
        _db.RegistrationCodes.Remove(regcode);
        return Save();
    }

    public RegistrationCode? GetRegistrationCodeByCode(string code)
    {
        return _db.RegistrationCodes.FirstOrDefault(rc => rc.Code == code);
    }

    public RegistrationCode? GetRegistrationCodeByEmail(string email)
    {
        return _db.RegistrationCodes.FirstOrDefault(rc => rc.Email == email);
    }

    public RegistrationCode? GetRegistrationCodeById(int id)
    {
        return _db.RegistrationCodes.FirstOrDefault(rc => rc.Id == id);
    }

    public IQueryable<RegistrationCode> GetRegistrationCodes()
    {
        return _db.RegistrationCodes;
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0;
    }

    public bool UpdateRegistrationCode(RegistrationCode regcode)
    {
        _db.RegistrationCodes.Update(regcode);
        return Save();
    }
}