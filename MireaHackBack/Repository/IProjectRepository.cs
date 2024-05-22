using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public interface IProjectRepository
{
    bool CreateProject(Project project);
    bool DeleteProject(Project project);
    Project? GetProjectById(long id);
    List<Project>? GetProjectsByUser(User user);
    bool Save();
    bool UpdateProject(Project project);
}