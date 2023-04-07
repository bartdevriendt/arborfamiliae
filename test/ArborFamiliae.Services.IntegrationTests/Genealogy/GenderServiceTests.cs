using ArborFamiliae.Shared.Services;

namespace ArborFamiliae.Services.IntegrationTests.Genealogy;

public class GenderServiceTests : TestBase
{
    [Test]
    public async Task Test_LoadAllGenders()
    {
        // arrange
        var genderService = GetService<IGenderService>();

        // act
        var genders = await genderService.GetGenders();

        // assert
        await Verify(genders).ToTask();
    }
}
