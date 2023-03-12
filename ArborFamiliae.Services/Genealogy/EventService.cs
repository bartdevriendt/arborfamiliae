using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Resources;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;
using Microsoft.Extensions.Localization;

namespace ArborFamiliae.Services.Genealogy;

public class EventService : ITransient
{
    private DateCalculationService _dateCalculationService;
    private IRepository<ArborEvent> _eventRepository;
    private IRepository<Person> _personRepository;
    private IReadRepository<Family> _familyReadRepository;
    private IStringLocalizer<ArborFamiliaeResources> _stringLocalizer;

    public EventService(
        DateCalculationService dateCalculationService,
        IRepository<ArborEvent> eventRepository,
        IRepository<Person> personRepository,
        IReadRepository<Family> familyReadRepository,
        IStringLocalizer<ArborFamiliaeResources> stringLocalizer
    )
    {
        _dateCalculationService = dateCalculationService;
        _eventRepository = eventRepository;
        _personRepository = personRepository;
        _familyReadRepository = familyReadRepository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<List<EventListModel>> GetEventsForPerson(Guid personId)
    {
        var events = await _eventRepository.ListAsync(new PersonEventListSpecification(personId));

        var personDetails = await _eventRepository.SingleOrDefaultAsync(
            new PersonEventListSpecification(personId)
        );

        var result = new List<EventListModel>();

        foreach (var personEvent in events)
        {
            EventListModel model = new EventListModel();
            model.Id = personEvent.Id;
            model.ArborId = personEvent.ArborId;
            model.Category = "Personal";
            model.Description = personEvent.Description;
            model.Type = _stringLocalizer[((EventType)personEvent.EventType).ToString()];
            //model.Role = _stringLocalizer[((EventRole)personEvent.EventRole).ToString()];
            model.Place = personEvent.Place?.Name;
            model.Date = personEvent.EventDate?.Text;
            result.Add(model);
        }

        return result;
    }

    public async Task<EventAddEditModel> GetEventById(Guid id)
    {
        var arborEvent = await _eventRepository.GetByIdAsync(id);
        var result = new EventAddEditModel
        {
            Id = arborEvent.Id,
            PlaceId = arborEvent.PlaceId,
            Description = arborEvent.Description,
            Role = EventRole.PRIMARY,
            Type = (EventType)arborEvent.EventType,
            ArborId = arborEvent.ArborId,
            PlaceName = arborEvent.Place?.Name,
            Date = FromArborDate(arborEvent.EventDate)
        };
        return result;
    }

    public async Task<EventAddEditModel> AddEditEventForPerson(
        Guid personId,
        EventAddEditModel model
    )
    {
        bool isNew = false;
        ArborEvent? arborEvent;
        PersonEvent? personEvent;

        if (model.Id == Guid.Empty)
        {
            arborEvent = new ArborEvent();
            arborEvent.Id = Guid.NewGuid();
            personEvent = new PersonEvent();
            personEvent.Id = Guid.NewGuid();
            personEvent.PersonId = personId;
            personEvent.EventId = arborEvent.Id;
            arborEvent.PersonEvents.Add(personEvent);
            isNew = true;
        }
        else
        {
            arborEvent = await _eventRepository.GetByIdAsync(model.Id);
            personEvent = arborEvent.PersonEvents.First(
                p => p.PersonId == personId && p.EventId == arborEvent.Id
            );
        }
        arborEvent.EventType = (int)model.Type;
        arborEvent.Description = model.Description;
        arborEvent.ArborId = model.ArborId;
        arborEvent.PlaceId = model.PlaceId;
        arborEvent.IsPrivate = false;
        if (model.Date != null)
        {
            arborEvent.EventDate = ToArborDate(model.Date);
        }

        personEvent.EventRole = (int)model.Role;

        if (isNew)
        {
            await _eventRepository.AddAsync(arborEvent);
        }
        else
        {
            await _eventRepository.UpdateAsync(arborEvent);
        }

        model.Id = arborEvent.Id;
        model.ArborId = arborEvent.ArborId;

        return model;
    }

    private ArborDateModel? FromArborDate(ArborDate? arborDate)
    {
        if (arborDate == null)
            return null;

        return new ArborDateModel
        {
            Text = arborDate.Text,
            Calendar = (DateCalendar)arborDate.Calendar,
            Day = arborDate.Day,
            Day2 = arborDate.Day2,
            Modifier = (DateModifier)arborDate.Modifier,
            Month = arborDate.Month,
            Month2 = arborDate.Month2,
            Year = arborDate.Year,
            Year2 = arborDate.Year2,
            NewYear = (DateNewYear)arborDate.NewYear,
            Quality = (DateQuality)arborDate.Quality,
            SlashDate1 = arborDate.SlashDate1,
            SortValue = arborDate.SortValue,
            SlashDate2 = arborDate.SlashDate2
        };
    }

    private ArborDate ToArborDate(ArborDateModel arborDateModel)
    {
        return new ArborDate
        {
            Text = arborDateModel.Text,
            Calendar = (int)arborDateModel.Calendar,
            Day = arborDateModel.Day,
            Day2 = arborDateModel.Day2,
            Modifier = (int)arborDateModel.Modifier,
            Month = arborDateModel.Month,
            Month2 = arborDateModel.Month2,
            Year = arborDateModel.Year,
            Year2 = arborDateModel.Year2,
            NewYear = (int)arborDateModel.NewYear,
            Quality = (int)arborDateModel.Quality,
            SlashDate1 = arborDateModel.SlashDate1,
            SortValue = arborDateModel.SortValue,
            SlashDate2 = arborDateModel.SlashDate2
        };
    }
}
