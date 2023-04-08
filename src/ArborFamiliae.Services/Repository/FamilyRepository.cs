using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Interfaces.Genealogy;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Repository;

public class FamilyRepository : GenericRepository<Family>, IFamilyRepository
{
    public FamilyRepository(
        ArborFamiliaeContext context,
        ISpecificationEvaluator specificationEvaluator
    )
        : base(context, specificationEvaluator) { }
}
