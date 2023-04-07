using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Places;
using ArborFamiliae.Services.Resources;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;
using ArborFamiliae.Shared.Services;
using Microsoft.Extensions.Localization;

namespace ArborFamiliae.Services.Genealogy;

public class PlaceService : IPlaceService
{
    private IReadRepository<Place> _placeReadRepository;
    private IRepository<Place> _placeRepository;

    private IStringLocalizer<ArborFamiliaeResources> _stringLocalizer;

    public PlaceService(
        IReadRepository<Place> placeReadRepository,
        IStringLocalizer<ArborFamiliaeResources> stringLocalizer,
        IRepository<Place> placeRepository
    )
    {
        _placeReadRepository = placeReadRepository;
        _stringLocalizer = stringLocalizer;
        _placeRepository = placeRepository;
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
                        Type = _stringLocalizer[((PlaceType)p.PlaceType).ToString()],
                        ParentPlaceId = p.EnclosedById
                    }
            )
            .ToList();
    }

    public async Task<PlaceAddEditModel> GetPlaceById(Guid id)
    {
        var place = await _placeReadRepository.GetByIdAsync(id);
        return new PlaceAddEditModel
        {
            Id = place.Id,
            ArborId = place.ArborId,
            Code = place.Code,
            Name = place.Name,
            PlaceType = (PlaceType)place.PlaceType,
            Latitude = place.Latitude,
            Longitude = place.Longitude,
            ParentPlaceId = place.EnclosedById,
            ParentPlaceName = place.EnclosedBy?.Name
        };
    }
    
    public async Task<PlaceAddEditModel?> GetPlaceByArborId(string arborId)
    {
        var place = await _placeReadRepository.FirstOrDefaultAsync(new PlaceByArborIdSpecification(arborId));
        if (place == null) return null;
        return new PlaceAddEditModel
        {
            Id = place.Id,
            ArborId = place.ArborId,
            Code = place.Code,
            Name = place.Name,
            PlaceType = (PlaceType)place.PlaceType,
            Latitude = place.Latitude,
            Longitude = place.Longitude,
            ParentPlaceId = place.EnclosedById,
            ParentPlaceName = place.EnclosedBy?.Name
        };
    }

    public async Task<PlaceAddEditModel> AddEditPlace(PlaceAddEditModel model)
    {
        Place? p = null;
        bool isNew = false;
        if (model.Id == Guid.Empty)
        {
            p = new Place();
            p.Id = Guid.NewGuid();
            isNew = true;
        }
        else
        {
            p = await _placeReadRepository.GetByIdAsync(model.Id);
        }

        p.Code = model.Code;
        p.Name = model.Name;
        p.PlaceType = (int)model.PlaceType;
        p.Latitude = model.Latitude;
        p.Longitude = model.Longitude;
        p.EnclosedById = model.ParentPlaceId;

        if (isNew)
        {
            await _placeRepository.AddAsync(p);
        }
        else
        {
            await _placeRepository.UpdateAsync(p);
        }

        model.Id = p.Id;
        return model;
    }
}
