using ArborFamiliae.Services.Genealogy;

namespace ArborFamiliae.Services.IntegrationTests.Genealogy;

public class EventServiceTests : TestBase
{
    [Test]
    public async Task Test_LoadAllEventsForPerson()
    {
        // arrange
        var eventService = GetService<PersonEventService>();
        var personService = GetService<PersonService>();

        var persons = await personService.GetAllPersons();

        // act
        var events = await eventService.GetEventsForPerson(
            persons.First(p => p.ArborId == "I00001").Id
        );

        // assert
        await Verify(events).ToTask();
    }
}
