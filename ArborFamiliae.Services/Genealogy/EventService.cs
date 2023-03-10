using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Shared.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ArborFamiliae.Services.Genealogy;

public class EventService : IScoped
{
    private DateCalculationService _dateCalculationService;
    private IReadRepository<ArborEvent> _eventReadRepository;
    private IReadRepository<Person> _personReadRepository;
    private IReadRepository<Family> _familyReadRepository;

    public EventService(
        DateCalculationService dateCalculationService,
        IReadRepository<ArborEvent> eventReadRepository,
        IReadRepository<Person> personReadRepository,
        IReadRepository<Family> familyReadRepository
    )
    {
        _dateCalculationService = dateCalculationService;
        _eventReadRepository = eventReadRepository;
        _personReadRepository = personReadRepository;
        _familyReadRepository = familyReadRepository;
    }

    public async Task<List<EventListModel>> GetEventsForPerson(Guid personId)
    {
        var personDetails = await _personReadRepository.GetByIdAsync(personId);

        var result = new List<EventListModel>();

        foreach (var personEvent in personDetails.Events)
        {
            EventListModel model = new EventListModel();
            model.Id = personEvent.EventId;
            model.ArborId = personEvent.Event.ArborId;
            model.Category = "Personal";
            model.Description = personEvent.Event.Description;
            model.Type = ((EventType)personEvent.Event.EventType).ToString();

            result.Add(model);
        }

        return result;
    }
}
