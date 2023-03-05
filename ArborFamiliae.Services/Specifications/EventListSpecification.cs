using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class EventListSpecification : Specification<ArborEvent>
{
    protected EventListSpecification(Guid personId)
    {
        Query.Where(x => x.PersonEvents.Any(x => x.PersonId == personId));
    }
}