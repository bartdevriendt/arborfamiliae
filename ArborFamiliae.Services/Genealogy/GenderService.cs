using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Domain.Person;
using ArborFamiliae.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Services.Genealogy;

public class GenderService : IScoped
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
            select new GenderModel { Description = g.Description, Id = g.Id }
        ).ToListAsync();
    }
}
