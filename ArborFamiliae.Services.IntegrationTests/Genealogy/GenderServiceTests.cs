using ArborFamiliae.Services.Genealogy;

namespace ArborFamiliae.Services.IntegrationTests.Genealogy;

public class GenderServQiceTests : TestBase
{
    [Test]
    public async Task Test_LoadAllGenders()
    {
        // arrange
        var genderService = GetService<GenderService>();

        // act
        var genders = await genderService.GetGenders();

        // assert
        await Verify(genders).ToTask();
    }
}
