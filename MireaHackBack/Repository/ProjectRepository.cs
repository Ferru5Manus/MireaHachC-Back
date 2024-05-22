using Microsoft.EntityFrameworkCore;
using MireaHackBack.Database;
using MireaHackBack.Database.Models;

namespace MireaHackBack.Repository;

public class ProjectRepository(ApplicationContext db) : IProjectRepository
{
    private readonly ApplicationContext _db = db;

    public bool CreateProject(Project project)
    {
        _db.Projects.Add(project);
        return Save();
    }

    public bool DeleteProject(Project project)
    {
        _db.Projects.Remove(project);
        return Save();
    }

    public Project? GetProjectById(long id)
    {
        return _db.Projects.FirstOrDefault(p => p.Id == id);
    }

    public List<Project>? GetProjectsByUser(User user)
    {
        return _db.Projects.Include(p => p.Owner)
        .Where(p => p.Owner.Id == user.Id).ToList();
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0;
    }

    public bool UpdateProject(Project project)
    {
        _db.Projects.Update(project);
        return Save();
    }
}