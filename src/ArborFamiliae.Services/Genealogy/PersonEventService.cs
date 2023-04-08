using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Interfaces.Base;
using ArborFamiliae.Services.Resources;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;
using ArborFamiliae.Shared.Services;
using Microsoft.Extensions.Localization;

namespace ArborFamiliae.Services.Genealogy;

public class PersonEventService : IPersonEventService
{
    private IStringLocalizer<ArborFamiliaeResources> _stringLocalizer;
    private IDateParserService _dateParserService;
    private IUnitOfWork _unitOfWork;

    public PersonEventService(
        IStringLocalizer<ArborFamiliaeResources> stringLocalizer,
        IDateParserService dateParserService,
        IUnitOfWork unitOfWork
    )
    {
        _stringLocalizer = stringLocalizer;
        _dateParserService = dateParserService;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<EventAddEditModel>> GetEventsForPerson(Guid personId)
    {
        var personEvents = await _unitOfWork.Person.FirstOrDefaultAsync(
            new PersonEventListSpecification(personId)
        );

        var familiesWithEvents = await _unitOfWork.Family.ListAsync(
            new PersonFamilyEventListSpecification(personId)
        );

        var result = new List<EventAddEditModel>();

        foreach (var personEvent in personEvents.Events)
        {
            ArborEvent arborEvent = personEvent.Event;

            EventAddEditModel model = new EventAddEditModel();
            model.Id = arborEvent.Id;
            model.ArborId = arborEvent.ArborId;
            model.Category = "Personal";
            model.Description = arborEvent.Description;
            model.Type = (EventType)arborEvent.EventType;
            model.TypeDescription = _stringLocalizer[((EventType)arborEvent.EventType).ToString()];
            model.Role = (EventRole)personEvent.EventRole;
            model.RoleDescription = _stringLocalizer[((EventRole)personEvent.EventRole).ToString()];
            model.PlaceId = arborEvent.PlaceId;
            model.PlaceName = arborEvent.Place?.Name;
            model.ListType = EventListType.Person;
            if (arborEvent.EventDate != null && arborEvent.EventDate.Text != null)
            {
                model.Date = _dateParserService.ParseDate(arborEvent.EventDate.Text);
            }
            model.DateText = arborEvent.EventDate?.Text;
            model.Participants = personEvents.DisplayName;
            result.Add(model);
        }

        foreach (var family in familiesWithEvents)
        {
            foreach (var familyEvent in family.Events)
            {
                ArborEvent arborEvent = familyEvent.Event;

                EventAddEditModel model = new EventAddEditModel();
                model.Id = arborEvent.Id;
                model.ArborId = arborEvent.ArborId;
                model.Category = "Family";
                model.Description = arborEvent.Description;
                model.Type = (EventType)arborEvent.EventType;
                model.TypeDescription = _stringLocalizer[
                    ((EventType)arborEvent.EventType).ToString()
                ];
                model.Role = (EventRole)familyEvent.EventRole;
                model.RoleDescription = _stringLocalizer[
                    ((EventRole)familyEvent.EventRole).ToString()
                ];
                model.PlaceId = arborEvent.PlaceId;
                model.PlaceName = arborEvent.Place?.Name;
                model.ListType = EventListType.Family;
                if (arborEvent.EventDate != null)
                {
                    model.Date = _dateParserService.ParseDate(arborEvent.EventDate.Text);
                }
                model.DateText = arborEvent.EventDate?.Text;
                model.Participants =
                    family.Father?.DisplayName + " and " + family.Mother?.DisplayName;
                result.Add(model);
            }
        }

        return result.OrderBy(x => x.ArborId).ToList();
    }

    public async Task<EventAddEditModel> GetEventById(Guid id)
    {
        var arborEvent = _unitOfWork.Event.GetById(id);
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
            arborEvent = _unitOfWork.Event.GetById(model.Id);
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
            _unitOfWork.Event.Add(arborEvent);
        }

        _unitOfWork.Save();

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
