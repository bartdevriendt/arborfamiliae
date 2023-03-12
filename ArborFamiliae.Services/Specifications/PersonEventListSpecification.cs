using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class PersonEventListSpecification : SingleResultSpecification<ArborEvent>
{
    public PersonEventListSpecification(Guid personId)
    {
        Query.Include(x => x.PersonEvents.Where(x => x.PersonId == personId));
    }
}
