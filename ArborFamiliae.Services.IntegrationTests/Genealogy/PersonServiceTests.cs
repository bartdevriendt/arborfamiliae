using ArborFamiliae.Services.Genealogy;
using ArborFamiliae.Services.IntegrationTests.Fixtures;
using FluentAssertions;

namespace ArborFamiliae.Services.IntegrationTests.Genealogy;

public class PersonServiceTests
{
    [SetUp]
    public void Setup()
    {
        var dbContext = GetDbContext();
        dbContext.SeedBasicData();
    }

    [Test]
    public async Task Test_LoadAllpersons()
    {
        // arrange

        // act
        var personService = GetService<PersonService>();
        var persons = await personService.GetAllPersons();

        // assert
        persons.Count.Should().Be(2);
        persons.Any(x => x.Surname == "Doe" && x.FirstName == "Jane").Should().BeTrue();
        persons.Any(x => x.Surname == "Smit" && x.FirstName == "Jan").Should().BeTrue();
    }

    [TearDown]
    public async Task Teardown()
    {
        await ResetState();
    }
}
