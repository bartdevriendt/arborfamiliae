using ArborFamiliae.Data.Models;
using Bogus;
using Person = ArborFamiliae.Data.Models.Person;

namespace ArborFamiliae.Services.IntegrationTests.Fixtures;

public sealed class ArborNameFaker : Faker<Name>
{
    public ArborNameFaker(Person p, bool primary = false)
    {
        RuleFor(x => x.Id, f => f.Random.Guid());
        RuleFor(x => x.FirstName, f => f.Name.FirstName());
        RuleFor(x => x.Call, f => f.Lorem.Word());
        RuleFor(x => x.Suffix, f => f.Name.Suffix());
        RuleFor(x => x.Title, f => f.Lorem.Word());
        RuleFor(x => x.Nickname, f => f.Lorem.Word());
        RuleFor(x => x.IsPrimary, f => primary);
        RuleFor(x => x.PersonId, f => p.Id);
        RuleFor(x => x.Surnames, (faker, name) => new SurnameFaker(name).Generate(1));
    }
}
