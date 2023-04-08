using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Interfaces.Genealogy;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Repository;

public class EventRepository : GenericRepository<ArborEvent>, IEventRepository
{
    public EventRepository(
        ArborFamiliaeContext context,
        ISpecificationEvaluator specificationEvaluator
    )
        : base(context, specificationEvaluator) { }
}
