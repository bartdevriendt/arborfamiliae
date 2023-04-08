using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Interfaces.Genealogy;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Repository;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(
        ArborFamiliaeContext context,
        ISpecificationEvaluator specificationEvaluator
    )
        : base(context, specificationEvaluator) { }
}
