using System.ComponentModel.DataAnnotations;

namespace MireaHackBack.Database.Models;

public class Project
{
    [Key]
    public long Id {get;set;}
    public string Type {get;set;} = null!;
    public User Owner {get;set;} = null!;
    public bool Published {get;set;} = false;
    public DateTime CreationDate {get;set;}
}