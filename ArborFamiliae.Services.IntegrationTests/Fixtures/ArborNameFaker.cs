using ArborFamiliae.Data.Models;
using Bogus;
using Person = ArborFamiliae.Data.Models.Person;

namespace ArborFamiliae.Services.IntegrationTests.Fixtures;

public sealed class ArborNameFaker : Faker<Name>
{
    public ArborNameFaker(Person p)
    {
        RuleFor(x => x.Id, f => f.Random.Guid());
        RuleFor(x => x.FirstName, f => f.Name.FirstName());
        RuleFor(x => x.Call, f => f.Lorem.Text());
        RuleFor(x => x.Suffix, f => f.Name.Suffix());
        RuleFor(x => x.Title, f => f.Lorem.Text());
        RuleFor(x => x.Nickname, f => f.Lorem.Text());
        RuleFor(x => x.PersonId, f => p.Id);
    }
}
