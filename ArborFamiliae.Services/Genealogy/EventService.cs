using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Genealogy;

public class EventService : IScoped
{
    private DateCalculationService _dateCalculationService;
    private IReadRepository<ArborEvent> _eventReadRepository;

    public EventService(
        DateCalculationService dateCalculationService,
        IReadRepository<ArborEvent> eventReadRepository
    )
    {
        _dateCalculationService = dateCalculationService;
        _eventReadRepository = eventReadRepository;
    }

    public List<EventListModel> GetEventsForPerson(Guid personId)
    {
        return null;
    }
}
