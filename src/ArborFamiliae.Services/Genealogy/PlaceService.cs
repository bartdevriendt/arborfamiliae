using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Enums;
using ArborFamiliae.Domain.Places;
using ArborFamiliae.Services.Interfaces.Base;
using ArborFamiliae.Services.Resources;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;
using ArborFamiliae.Shared.Services;
using Microsoft.Extensions.Localization;

namespace ArborFamiliae.Services.Genealogy;

public class PlaceService : IPlaceService
{
    private IStringLocalizer<ArborFamiliaeResources> _stringLocalizer;
    private IUnitOfWork _unitOfWork;

    public PlaceService(
        IStringLocalizer<ArborFamiliaeResources> stringLocalizer,
        IUnitOfWork unitOfWork
    )
    {
        _stringLocalizer = stringLocalizer;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PlaceListModel>> GetAllPlaces()
    {
        var places = await _unitOfWork.Place.ListAsync();
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
        var place = _unitOfWork.Place.GetById(id);
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
        var place = await _unitOfWork.Place.FirstOrDefaultAsync(
            new PlaceByArborIdSpecification(arborId)
        );
        if (place == null)
            return null;
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
            p = _unitOfWork.Place.GetById(model.Id);
        }

        p.Code = model.Code;
        p.Name = model.Name;
        p.PlaceType = (int)model.PlaceType;
        p.Latitude = model.Latitude;
        p.Longitude = model.Longitude;
        p.EnclosedById = model.ParentPlaceId;

        if (isNew)
        {
            _unitOfWork.Place.Add(p);
        }

        _unitOfWork.Save();

        model.Id = p.Id;
        model.ArborId = p.ArborId;
        return model;
    }
}
