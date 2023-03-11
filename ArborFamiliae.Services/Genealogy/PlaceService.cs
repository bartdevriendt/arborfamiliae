using ArborFamiliae.Data.Models;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Genealogy;

public class PlaceService : IScoped
{
    private IReadRepository<Place> _placeReadRepository;


    public PlaceService(IReadRepository<Place> placeReadRepository)
    {
        _placeReadRepository = placeReadRepository;
    }
    
    
}