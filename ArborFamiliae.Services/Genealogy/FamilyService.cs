using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Family;
using ArborFamiliae.Shared.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArborFamiliae.Services.Genealogy;

public class FamilyService : ITransient
{
    private IRepository<Family> _familyRepository;

    public FamilyService(IRepository<Family> familyRepository)
    {
        _familyRepository = familyRepository;
    }

    public async Task<List<FamilyListModel>> LoadAllFamilies()
    {
        var families = await _familyRepository.ListAsync();
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
}
