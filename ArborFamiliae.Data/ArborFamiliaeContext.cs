using ArborFamiliae.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Data
{
    public class ArborFamiliaeContext : DbContext
    {
        public ArborFamiliaeContext(DbContextOptions<ArborFamiliaeContext> options)
            : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

        public static void InitializeAsync(ArborFamiliaeContext db)
        {
            db.Database.Migrate();

        }
    }
}