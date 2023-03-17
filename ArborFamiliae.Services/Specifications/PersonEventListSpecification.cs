using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class PersonEventListSpecification : SingleResultSpecification<Person>
{
    public PersonEventListSpecification(Guid personId)
    {
        Query.Where(p => p.Id == personId);
        Query.Include(p => p.Events).ThenInclude(pe => pe.Event);
    }
}
