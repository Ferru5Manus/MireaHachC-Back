using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public interface IUserProfileRepository
{
    public IQueryable<UserProfile> GetUsersProfiles();
    public UserProfile? GetUserProfileById(int id);
    public UserProfile? GetUserProfileByUserId(int userId);
    public UserProfile? GetUserProfileByUsername(string username);
    public UserProfile? GetUserProfileByEmail(string email);
    public bool CreateUserProfile(UserProfile user);
    public bool UpdateUserProfile(UserProfile user);
    public bool DeleteUserProfile(UserProfile user);
    public bool Save();
}