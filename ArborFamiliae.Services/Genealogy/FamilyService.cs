using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Family;
using ArborFamiliae.Shared.Interfaces;

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

        foreach (var family in families)
        {
            FamilyListModel model = new FamilyListModel();
        }
    }
}
