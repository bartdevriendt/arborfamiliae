using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Services.Interfaces.Base;
using ArborFamiliae.Shared.Interfaces;
using ArborFamiliae.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Services.Genealogy;

public class GenderService : IGenderService
{
    private IUnitOfWork _unitOfWork;

    public GenderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GenderModel>> GetGenders()
    {
        var genders = await _unitOfWork.Gender.ListAsync();

        return (
            from Gender g in genders
            orderby g.SortOrder
            select new GenderModel { Description = g.Description, Id = g.Id }
        ).ToList();
    }
}
