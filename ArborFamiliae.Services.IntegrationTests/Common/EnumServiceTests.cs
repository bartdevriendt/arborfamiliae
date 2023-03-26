using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.IntegrationTests.Genealogy;

namespace ArborFamiliae.Services.IntegrationTests.Common;

public class EnumServiceTests : TestBase
{
    [Test]
    [Culture("en")]
    public async Task Test_LoadEnums()
    {
        // arrange
        var enumService = GetService<EnumService>();
        // act
        var enumTypes = enumService.GetEnumTypes<PlaceType>();

        // assert
        await Verify(enumTypes).ToTask();
    }
}
