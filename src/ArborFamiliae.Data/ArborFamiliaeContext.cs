﻿using ArborFamiliae.Data.Models;
using ArborFamiliae.Data.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Data;

public class ArborFamiliaeContext : DbContext
{
    public ArborFamiliaeContext(DbContextOptions options) : base(options) { }

    public DbSet<ArborEvent> Events { set; get; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonEvent> PersonEvents { get; set; }
    public DbSet<FamilyEvent> FamilyEvents { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<FamilyChild> FamilyChildren { get; set; }

    public DbSet<Place> Places { get; set; }
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
            db.Genders.Add(
                new Gender
                {
                    Id = Guid.NewGuid(),
                    SortOrder = 1,
                    Description = "Male"
                }
            );
            db.Genders.Add(
                new Gender
                {
                    Id = Guid.NewGuid(),
                    SortOrder = 2,
                    Description = "Female"
                }
            );
            db.Genders.Add(
                new Gender
                {
                    Id = Guid.NewGuid(),
                    SortOrder = 3,
                    Description = "Unknown"
                }
            );
            db.SaveChanges();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<ArborDate>().HaveConversion<DateConverter>();
    }
}
