using Microsoft.EntityFrameworkCore;
using MireaHackBack.Database.Models;
namespace MireaHackBack.Database;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<RegistrationCode> RegistrationCodes { get; set; }
    public DbSet<ResetCode> ResetCodes { get; set; }

    #pragma warning disable CS8618
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
	
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}