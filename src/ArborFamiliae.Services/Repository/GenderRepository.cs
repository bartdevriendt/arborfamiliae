using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Interfaces.Genealogy;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Repository;

public class GenderRepository : GenericRepository<Gender>, IGenderRepository
{
    public GenderRepository(
        ArborFamiliaeContext context,
        ISpecificationEvaluator specificationEvaluator
    )
        : base(context, specificationEvaluator) { }
}
