using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class PersonByArborIdSpecification : SingleResultSpecification<Person>
{
    public PersonByArborIdSpecification(string arborId)
    {
        Query.Where(p => p.ArborId == arborId);
        Query.Include(p => p.Events).ThenInclude(e => e.Event);
        Query.Include(p => p.Names).ThenInclude(n => n.Surnames);
        Query.Include(p => p.Gender);
    }
}