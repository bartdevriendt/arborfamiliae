using Bogus;
using Person = ArborFamiliae.Data.Models.Person;

namespace ArborFamiliae.Services.IntegrationTests.Fixtures;

public sealed class PersonFaker : Faker<Person>
{
    public PersonFaker()
    {
        RuleFor(x => x.Id, f => f.Random.Guid());
        RuleFor(x => x.ArborId, f => f.Lorem.Word());
        RuleFor(x => x.GenderId, f => f.PickRandom(HelperStuff.Genders));
        RuleFor(x => x.IsPrivate, f => f.Random.Bool());
        RuleFor(x => x.Names, (faker, person) => new ArborNameFaker(person, true).Generate(1));
    }
}
