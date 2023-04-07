using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.IntegrationTests.Genealogy;
using ArborFamiliae.Shared.Services;

namespace ArborFamiliae.Services.IntegrationTests.Common;

public class EnumServiceTests : TestBase
{
    [Test]
    [Culture("en")]
    public async Task Test_LoadEnums()
    {
        // arrange
        var enumService = GetService<IEnumService>();
        // act
        var enumTypes = enumService.GetEnumTypes<PlaceType>();

        // assert
        await Verify(enumTypes).ToTask();
    }
}
