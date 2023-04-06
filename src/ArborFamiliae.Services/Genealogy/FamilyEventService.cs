using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Resources;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;
using Microsoft.Extensions.Localization;

namespace ArborFamiliae.Services.Genealogy;

public class FamilyEventService : ITransient
{
    
    
    private IReadRepository<Family> _familyRepository;
    private IStringLocalizer<ArborFamiliaeResources> _stringLocalizer;
    private PersonEventService _personEventService;
    private DateParserService _dateParserService;

    public FamilyEventService(IReadRepository<Family> familyRepository, IStringLocalizer<ArborFamiliaeResources> stringLocalizer, PersonEventService personEventService, DateParserService dateParserService)
    {
        _familyRepository = familyRepository;
        _stringLocalizer = stringLocalizer;
        _personEventService = personEventService;
        _dateParserService = dateParserService;
    }

    public async Task<List<EventAddEditModel>> GetEventsForFamily(Guid familyId)
    {
        var familyEvents = await _familyRepository.FirstOrDefaultAsync(new FamilyEventListSpecification(familyId));
        var result = new List<EventAddEditModel>();

        foreach (var familyEvent in familyEvents.Events)
        {
            ArborEvent arborEvent = familyEvent.Event;

            EventAddEditModel model = new EventAddEditModel();
            model.Id = arborEvent.Id;
            model.ArborId = arborEvent.ArborId;
            model.Category = "Family";
            model.Description = arborEvent.Description;
            model.Type = (EventType)arborEvent.EventType;
            model.TypeDescription = _stringLocalizer[((EventType)arborEvent.EventType).ToString()];
            model.Role = (EventRole)familyEvent.EventRole;
            model.RoleDescription = _stringLocalizer[((EventRole)familyEvent.EventRole).ToString()];
            model.PlaceId = arborEvent.PlaceId;
            model.PlaceName = arborEvent.Place?.Name;
            model.ListType = EventListType.Family;
            
            if (arborEvent.EventDate != null)
            {
                model.Date = _dateParserService.ParseDate(arborEvent.EventDate.Text);    
            }
            
            model.DateText = arborEvent.EventDate?.Text; 
            model.Participants = familyEvents.Father?.DisplayName + " and " + familyEvents.Mother?.DisplayName;
            result.Add(model);
        }

        if (familyEvents.Father != null)
        {
            var fatherEvents = await _personEventService.GetEventsForPerson(familyEvents.Father.Id);

            foreach (var m in fatherEvents)
            {
                if (m.ListType == EventListType.Person)
                {
                    m.Category = "Father";
                    result.Add(m);    
                }
            }
        }
        
        if (familyEvents.Mother != null)
        {
            var motherEvents = await _personEventService.GetEventsForPerson(familyEvents.Mother.Id);

            foreach (var m in motherEvents)
            {
                if (m.ListType == EventListType.Person)
                {
                    m.Category = "Mother";
                    result.Add(m);    
                }
            }
        }

        return result;
    }
}