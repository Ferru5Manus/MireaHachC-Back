using Microsoft.EntityFrameworkCore;
using MireaHackBack.Database;
using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public class ResetCodeRepository : IResetCodeRepository
{
    private readonly ApplicationContext _db;

    public ResetCodeRepository(ApplicationContext db)
    {
        _db = db;
    }

    public bool CreateResetCode(ResetCode resetCode)
    {
        _db.ResetCodes.Add(resetCode);
        return Save(); 
    }

    public bool DeleteResetCode(ResetCode resetCode)
    {
        _db.ResetCodes.Remove(resetCode);
        return Save();
    }

    public ResetCode? GetResetCodeByCode(string code)
    {
        return _db.ResetCodes.FirstOrDefault(rc => rc.Code == code);
    }

    public ResetCode? GetResetCodeByEmail(string email)
    {
        return _db.ResetCodes
        .Include(rc => rc.User)
        .FirstOrDefault(rc => rc.User.Email == email);
    }

    public ResetCode? GetResetCodeById(long id)
    {
        return _db.ResetCodes.FirstOrDefault(rc => rc.Id == id);
    }

    public ResetCode? GetResetCodeByUsername(string username)
    {
        return _db.ResetCodes
        .Include(rc => rc.User)
        .FirstOrDefault(rc => rc.User.Username == username);
    }

    public IQueryable<ResetCode> GetResetCodes()
    {
        return _db.ResetCodes;
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0;
    }

    public bool UpdateResetCode(ResetCode resetCode)
    {
        _db.ResetCodes.Update(resetCode);
        return Save();
    }
}