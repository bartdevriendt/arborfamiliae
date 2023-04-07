using ArborFamiliae.Shared.Services;

namespace ArborFamiliae.Services.IntegrationTests.Genealogy;

public class EventServiceTests : TestBase
{
    [Test]
    public async Task Test_LoadAllEventsForPerson()
    {
        // arrange
        var eventService = GetService<IPersonEventService>();
        var personService = GetService<IPersonService>();

        var persons = await personService.GetAllPersons();

        // act
        var events = await eventService.GetEventsForPerson(
            persons.First(p => p.ArborId == "I00001").Id
        );

        // assert
        await Verify(events).ToTask();
    }
}
