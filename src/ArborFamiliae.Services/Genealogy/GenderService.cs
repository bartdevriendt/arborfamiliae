using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Shared.Interfaces;
using ArborFamiliae.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Services.Genealogy;

public class GenderService : IGenderService
{
    private ArborFamiliaeContext context;

    public GenderService(ArborFamiliaeContext context)
    {
        this.context = context;
    }

    public async Task<List<GenderModel>> GetGenders()
    {
        return await (
            from Gender g in context.Genders
            orderby g.SortOrder
            select new GenderModel { Description = g.Description, Id = g.Id }
        ).ToListAsync();
    }
}
