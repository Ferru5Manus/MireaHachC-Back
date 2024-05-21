using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public interface IResetCodeRepository
{
    public IQueryable<ResetCode> GetResetCodes();
    public ResetCode? GetResetCodeById(long id);
    public ResetCode? GetResetCodeByEmail(string email);
    public ResetCode? GetResetCodeByUsername(string username);
    public ResetCode? GetResetCodeByCode(string code);
    public bool CreateResetCode(ResetCode resetCode);
    public bool UpdateResetCode(ResetCode resetCode);
    public bool DeleteResetCode(ResetCode resetCode);
    public bool Save();   
}