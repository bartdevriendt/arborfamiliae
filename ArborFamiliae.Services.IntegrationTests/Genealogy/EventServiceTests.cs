﻿using ArborFamiliae.Services.Genealogy;

namespace ArborFamiliae.Services.IntegrationTests.Genealogy;

public class EventServiceTests : TestBase
{
    [Test]
    public async Task Test_LoadAllEventsForPerson()
    {
        // arrange
        var eventService = GetService<EventService>();
        var personService = GetService<PersonService>();

        var persons = await personService.GetAllPersons();

        // act
        var events = await eventService.GetEventsForPerson(persons[0].Id);

        // assert
        await Verify(events).ToTask();
    }
}
