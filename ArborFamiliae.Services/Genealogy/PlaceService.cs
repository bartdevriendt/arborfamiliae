using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Places;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Genealogy;

public class PlaceService : IScoped
{
    private IReadRepository<Place> _placeReadRepository;

    public PlaceService(IReadRepository<Place> placeReadRepository)
    {
        _placeReadRepository = placeReadRepository;
    }

    public async Task<List<PlaceListModel>> GetAllPlaces()
    {
        var places = await _placeReadRepository.ListAsync();
        return places
            .Select(
                p =>
                    new PlaceListModel()
                    {
                        Id = p.Id,
                        ArborId = p.ArborId,
                        Code = p.Code,
                        Name = p.Name,
                        Type = ((PlaceType)p.PlaceType).ToString(),
                        ParentPlaceId = p.EnclosedById
                    }
            )
            .ToList();
    }
}
