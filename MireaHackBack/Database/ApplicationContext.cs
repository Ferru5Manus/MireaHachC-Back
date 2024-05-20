using Microsoft.EntityFrameworkCore;
using MireaHack.Database.Models;
namespace MireaHack.Database;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    #pragma warning disable CS8618
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
	
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}