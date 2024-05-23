using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public interface IUserRepository
{
    public IQueryable<User> GetUsers();
    public User? GetUserById(int id);
    public User? GetUserByUsername(string username);
    public User? GetUserByEmail(string email);
    public bool CreateUser(User user);
    public bool UpdateUser(User user);
    public bool DeleteUser(User user);
    public bool Save();
}