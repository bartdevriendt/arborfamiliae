using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Family;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Genealogy;

public class FamilyService : ITransient
{
    private IRepository<Family> _familyRepository;
    private FamilyEventService _familyEventService;
    public FamilyService(IRepository<Family> familyRepository, FamilyEventService familyEventService)
    {
        _familyRepository = familyRepository;
        _familyEventService = familyEventService;
    }

    public async Task<List<FamilyListModel>> LoadAllFamilies()
    {
        var families = await _familyRepository.ListAsync(new FamilyListSpecification());
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
        var family = await _familyRepository.FirstOrDefaultAsync(
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
            f = await _familyRepository.GetByIdAsync(model.Id);
        }

        f.FatherId = model.FatherId;
        f.MotherId = model.MotherId;

        if (isNew)
        {
            await _familyRepository.AddAsync(f);
        }
        else
        {
            await _familyRepository.UpdateAsync(f);
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

        await _familyRepository.UpdateAsync(f);

        return model;
    }
}
