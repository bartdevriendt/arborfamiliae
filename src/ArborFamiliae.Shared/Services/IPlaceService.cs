using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArborFamiliae.Domain.Places;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Shared.Services;

public interface IPlaceService : ITransient
{
    Task<List<PlaceListModel>> GetAllPlaces();
    Task<PlaceAddEditModel> GetPlaceById(Guid id);
    Task<PlaceAddEditModel?> GetPlaceByArborId(string arborId);
    Task<PlaceAddEditModel> AddEditPlace(PlaceAddEditModel model);
}