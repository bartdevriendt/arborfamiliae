using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using Bogus;
using Person = ArborFamiliae.Data.Models.Person;

namespace ArborFamiliae.Services.IntegrationTests.Fixtures;

public static class DbContextExtensions
{
    public static void SeedBasicData(this ArborFamiliaeContext context)
    {
        if (!context.Genders.Any())
        {
            context
                .Set<Gender>()
                .AddRange(
                    new Gender()
                    {
                        Id = Guid.Parse("7f70fb8b-0838-453a-bcb5-8fd98daab453"),
                        Description = "Male",
                        SortOrder = 0
                    },
                    new Gender()
                    {
                        Id = Guid.Parse("9e95bbaa-1da8-4e16-b7c2-3391d2714f3f"),
                        Description = "Female",
                        SortOrder = 1
                    },
                    new Gender()
                    {
                        Id = Guid.Parse("bd9532e2-196c-420a-a924-0973186071ce"),
                        Description = "Unknown",
                        SortOrder = 2
                    }
                );
        }

        context.SaveChanges();


        PersonFaker personFaker = new PersonFaker();
        var persons = personFaker.Generate(5);
        context.Set<Person>().AddRange(persons);
        context.SaveChanges();

        // context
        //     .Set<Person>()
        //     .AddRange(
        //         new Person()
        //         {
        //             Id = Guid.NewGuid(),
        //             Gender = context.Genders.First(x => x.Description == "Male"),
        //             ArborId = "P0001",
        //             PrimaryName = new Name()
        //             {
        //                 Id = Guid.NewGuid(),
        //                 FirstName = "Jan",
        //                 Surnames = new List<Surname>()
        //                 {
        //                     new Surname()
        //                     {
        //                         Primary = true,
        //                         Id = new Guid(),
        //                         SurnameValue = "Smit"
        //                     }
        //                 }
        //             }
        //         },
        //         new Person()
        //         {
        //             Id = Guid.NewGuid(),
        //             Gender = context.Genders.First(x => x.Description == "Female"),
        //             ArborId = "P0002",
        //             PrimaryName = new Name()
        //             {
        //                 Id = Guid.NewGuid(),
        //                 FirstName = "Jane",
        //                 Surnames = new List<Surname>()
        //                 {
        //                     new Surname()
        //                     {
        //                         Primary = true,
        //                         Id = new Guid(),
        //                         SurnameValue = "Doe"
        //                     }
        //                 }
        //             }
        //         }
        //     );
        //
        // context.SaveChanges();
    }
}
