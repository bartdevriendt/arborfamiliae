using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Interfaces.Genealogy;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Services.Repository;

public class GenderRepository : GenericRepository<Gender>, IGenderRepository
{
    public GenderRepository(
        IDbContextFactory<ArborFamiliaeContext> context,
        ISpecificationEvaluator specificationEvaluator
    )
        : base(context, specificationEvaluator) { }
}
