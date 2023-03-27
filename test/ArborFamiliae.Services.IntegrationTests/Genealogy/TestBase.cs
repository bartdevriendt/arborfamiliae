using System.Reflection;
using ArborFamiliae.Services.IntegrationTests.TestData;
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

        await SetupBaseData("base_data.json");
    }

    [TearDown]
    public async Task Teardown()
    {
        await ResetState();
    }

    protected string LoadFile(string filename)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "ArborFamiliae.Services.IntegrationTests.TestData." + filename;
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        {
            using (StreamReader rdr = new StreamReader(stream))
            {
                return rdr.ReadToEnd();
            }
        }
    }

    protected Task SetupBaseData(string filename)
    {
        string jsonString = LoadFile(filename);
        DataLoader dl = new DataLoader(GetDbContext());
        dl.LoadData(jsonString);
        return Task.CompletedTask;
    }
}
