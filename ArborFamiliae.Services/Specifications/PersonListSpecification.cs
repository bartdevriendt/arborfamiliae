using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class PersonListSpecification : Specification<Person>
{
    public PersonListSpecification(Guid? gender)
    {
        if (gender != null)
        {
            Query.Where(p => p.GenderId == gender);
        }
    }
}
