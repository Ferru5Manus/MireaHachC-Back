using Microsoft.EntityFrameworkCore;
using MireaHackBack.Database;
using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public class UserProfileRepository(ApplicationContext db) : IUserProfileRepository
{
    private readonly ApplicationContext _db = db;

    public bool CreateUserProfile(UserProfile user)
    {
        _db.UserProfiles.Add(user);
        return Save();
    }

    public bool DeleteUserProfile(UserProfile user)
    {
        _db.UserProfiles.Remove(user);
        return Save();
    }

    public UserProfile? GetUserProfileByEmail(string email)
    {
        return _db.UserProfiles.Include(u => u.User)
            .FirstOrDefault(up => up.User.Email == email);
    }

    public UserProfile? GetUserProfileById(long id)
    {
        return _db.UserProfiles.FirstOrDefault(up => up.Id == id);
    }

    public UserProfile? GetUserProfileByUserId(long userId)
    {
        return _db.UserProfiles.Include(u => u.User)
            .FirstOrDefault(up => up.User.Id == userId);
    }

    public UserProfile? GetUserProfileByUsername(string username)
    {
        return _db.UserProfiles.Include(u => u.User)
            .FirstOrDefault(up => up.User.Username == username);
    }

    public IQueryable<UserProfile> GetUsersProfiles()
    {
        return _db.UserProfiles;
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0;
    }

    public bool UpdateUserProfile(UserProfile user)
    {
        _db.UserProfiles.Update(user);
        return Save();
    }
}