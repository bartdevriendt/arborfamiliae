using Bogus;

namespace ArborFamiliae.Services.IntegrationTests.Genealogy;

[TestFixture]
public class TestBase
{
    [SetUp]
    public async Task TestSetup()
    {
        Randomizer.Seed = new Random(789123);
        await ResetState();

        SeedData();
    }

    [TearDown]
    public async Task Teardown()
    {
        await ResetState();
    }
}
