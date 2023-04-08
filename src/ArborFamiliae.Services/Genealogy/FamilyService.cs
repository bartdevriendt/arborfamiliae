using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Events;
using ArborFamiliae.Domain.Family;
using ArborFamiliae.Services.Interfaces.Base;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;
using ArborFamiliae.Shared.Services;

namespace ArborFamiliae.Services.Genealogy;

public class FamilyService : IFamilyService
{
    private IFamilyEventService _familyEventService;
    private IUnitOfWork _unitOfWork;

    public FamilyService(IFamilyEventService familyEventService, IUnitOfWork unitOfWork)
    {
        _familyEventService = familyEventService;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<FamilyListModel>> LoadAllFamilies()
    {
        var families = await _unitOfWork.Family.ListAsync(new FamilyListSpecification());
        var result = new List<FamilyListModel>();

        foreach (var family in families.OrderBy(f => f.ArborId))
        {
            FamilyListModel model = new FamilyListModel();

            model.Father = family.Father?.DisplayName;
            model.Mother = family.Mother?.DisplayName;
            model.Relationship = "Unknown";
            model.ArborId = family.ArborId;
            model.MarriageDate = "";
            model.Id = family.Id;

            result.Add(model);
        }

        return result;
    }

    public async Task<FamilyAddEditModel> GetFamilyById(Guid familyId)
    {
        var family = await _unitOfWork.Family.FirstOrDefaultAsync(
            new FamilyListSpecification(familyId)
        );
        var model = new FamilyAddEditModel();

        model.FatherId = family.FatherId;
        model.MotherId = family.MotherId;
        model.ArborId = family.ArborId;
        if (family.Father != null)
        {
            model.FatherDisplayName =
                family.Father?.DisplayName + " [" + family.Father?.ArborId + "]";
            model.FatherBirthDate = family.Father?.BirthDate;
            model.FatherDeathDate = family.Father?.DeathDate;
        }

        if (family.Mother != null)
        {
            model.MotherDisplayName =
                family.Mother?.DisplayName + " [" + family.Mother?.ArborId + "]";
            model.MotherBirthDate = family.Mother?.BirthDate;
            model.MotherDeathDate = family.Mother?.DeathDate;
        }
        model.Id = family.Id;

        int order = 1;
        foreach (FamilyChild fc in family.Children)
        {
            FamilyChildAddEditModel fcm =
                new()
                {
                    Id = fc.Id,
                    Order = order++,
                    Name = fc.Child.DisplayName,
                    Gender = fc.Child.Gender.Description,
                    BirthDate = fc.Child.BirthDate,
                    PaternalRelation = "",
                    MaternalRelation = "",
                    PersonId = fc.ChildId,
                    FamiliyId = fc.FamilyId,
                    ArborId = fc.Child.ArborId
                };

            model.Children.Add(fcm);
        }

        model.Events = await _familyEventService.GetEventsForFamily(familyId);

        return model;
    }

    public async Task<FamilyAddEditModel?> GetFamilyByArborId(string arborId)
    {
        var family = await _unitOfWork.Family.FirstOrDefaultAsync(
            new FamilyByArborIdSpecification(arborId)
        );

        if (family == null)
            return null;

        var model = new FamilyAddEditModel();

        model.FatherId = family.FatherId;
        model.MotherId = family.MotherId;
        model.ArborId = family.ArborId;
        if (family.Father != null)
        {
            model.FatherDisplayName =
                family.Father?.DisplayName + " [" + family.Father?.ArborId + "]";
            model.FatherBirthDate = family.Father?.BirthDate;
            model.FatherDeathDate = family.Father?.DeathDate;
        }

        if (family.Mother != null)
        {
            model.MotherDisplayName =
                family.Mother?.DisplayName + " [" + family.Mother?.ArborId + "]";
            model.MotherBirthDate = family.Mother?.BirthDate;
            model.MotherDeathDate = family.Mother?.DeathDate;
        }
        model.Id = family.Id;

        int order = 1;
        foreach (FamilyChild fc in family.Children)
        {
            FamilyChildAddEditModel fcm =
                new()
                {
                    Id = fc.Id,
                    Order = order++,
                    Name = fc.Child.DisplayName,
                    Gender = fc.Child.Gender.Description,
                    BirthDate = fc.Child.BirthDate,
                    PaternalRelation = "",
                    MaternalRelation = "",
                    PersonId = fc.ChildId,
                    FamiliyId = fc.FamilyId,
                    ArborId = fc.Child.ArborId
                };

            model.Children.Add(fcm);
        }

        model.Events = await _familyEventService.GetEventsForFamily(model.Id);

        return model;
    }

    public async Task<FamilyAddEditModel> AddEditFamily(FamilyAddEditModel model)
    {
        Family? f;
        bool isNew = false;

        if (model.Id == Guid.Empty)
        {
            f = new Family();
            f.Id = Guid.NewGuid();
            isNew = true;
        }
        else
        {
            f = _unitOfWork.Family.GetById(model.Id);
        }

        f.FatherId = model.FatherId;
        f.MotherId = model.MotherId;

        if (isNew)
        {
            f = _unitOfWork.Family.Add(f);
        }

        model.Id = f.Id;
        model.ArborId = f.ArborId;

        foreach (var child in model.Children)
        {
            if (child.Id == Guid.Empty && child.PersonId != null)
            {
                var familyChild = new FamilyChild
                {
                    Id = Guid.NewGuid(),
                    FamilyId = f.Id,
                    ChildId = child.PersonId.Value
                };
                f.Children.Add(familyChild);

                child.Id = familyChild.Id;
            }
        }

        foreach (var familyEvent in model.Events)
        {
            if (familyEvent.ListType != EventListType.Family)
                continue;

            var arborEvent = new ArborEvent();
            if (familyEvent.Id == Guid.Empty)
            {
                arborEvent.Id = Guid.NewGuid();
                FamilyEvent fe = new FamilyEvent();
                fe.Id = Guid.NewGuid();
                fe.Family = f;
                fe.Event = arborEvent;
                fe.EventRole = (int)familyEvent.Role;
                f.Events.Add(fe);
                familyEvent.Id = arborEvent.Id;
            }
            else
            {
                arborEvent =
                    f.Events.FirstOrDefault(x => x.EventId == familyEvent.Id)?.Event
                    ?? throw new Exception("Event not found");
            }
            arborEvent.Description = familyEvent.Description;
            arborEvent.EventDate = ToArborDate(familyEvent.Date);
            arborEvent.EventType = (int)familyEvent.Type;
            arborEvent.PlaceId = familyEvent.PlaceId;
        }

        _unitOfWork.Save();

        List<ArborEvent> deleteArborEvent = new();

        foreach (var deletedEvent in model.DeletedEvents)
        {
            if (deletedEvent.ListType != EventListType.Family)
                continue;

            var familyEvent =
                f.Events.FirstOrDefault(x => x.EventId == deletedEvent.Id)
                ?? throw new Exception("Event not found");
            deleteArborEvent.Add(_unitOfWork.Event.GetById(familyEvent.Event.Id));

            f.Events.Remove(familyEvent);
        }

        _unitOfWork.Save();

        if (deleteArborEvent.Count > 0)
        {
            _unitOfWork.Event.RemoveRange(deleteArborEvent);
        }

        return model;
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
