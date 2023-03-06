using ArborFamiliae.Data.Models;
using Bogus;

namespace ArborFamiliae.Services.IntegrationTests.Fixtures;

public sealed class SurnameFaker : Faker<Surname>
{
    public SurnameFaker(Name parentName, bool primary = true)
    {
        RuleFor(x => x.Id, f => f.Random.Guid());
        RuleFor(x => x.NameId, f => parentName.Id);
        RuleFor(x => x.Primary, f => primary);
        RuleFor(x => x.SurnameValue, f => f.Name.LastName());
    }
}
