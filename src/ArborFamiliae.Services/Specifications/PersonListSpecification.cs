using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class PersonListSpecification : Specification<Person>
{
    public PersonListSpecification(Guid? gender = null)
    {
        if (gender != null)
        {
            Query.Where(p => p.GenderId == gender);
        }

        Query.Include(p => p.Events).ThenInclude(e => e.Event);
        Query.Include(p => p.Names).ThenInclude(n => n.Surnames);
        Query.Include(p => p.Gender);

        Query.OrderBy(p => p.ArborId);
        Query.AsSplitQuery();
    }
}
