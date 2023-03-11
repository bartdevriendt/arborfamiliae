using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class PersenEventListSpecification : SingleResultSpecification<Person>
{
    public PersenEventListSpecification(Guid personId)
    {
        Query.Where(x => x.Id == personId).Include(x => x.Events).ThenInclude(y => y.Event);
    }
}
