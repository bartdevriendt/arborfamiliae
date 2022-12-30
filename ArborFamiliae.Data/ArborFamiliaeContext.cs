using ArborFamiliae.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Data;

public class ArborFamiliaeContext : DbContext
{
    public ArborFamiliaeContext(DbContextOptions<ArborFamiliaeContext> options) : base(options) { }

    public DbSet<Gender> Genders { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Sequence> Sequences { get; set; }

    public static void InitializeAsync(ArborFamiliaeContext db)
    {
        db.Database.Migrate();
        Seed(db);
    }

    private static void Seed(ArborFamiliaeContext db)
    {
        if (!db.Genders.Any())
        {
            db.Genders.Add(new Gender { Id = Guid.NewGuid(), SortOrder = 1, Description = "Male" });
            db.Genders.Add(new Gender { Id = Guid.NewGuid(), SortOrder = 2, Description = "Female" });
            db.Genders.Add(new Gender { Id = Guid.NewGuid(), SortOrder = 3, Description = "Unknown" });
            db.SaveChanges();
        }
    }
}
