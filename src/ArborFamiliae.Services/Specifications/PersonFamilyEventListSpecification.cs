using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class PersonFamilyEventListSpecification: Specification<Family>
{
    public PersonFamilyEventListSpecification(Guid personId) 
    {
        Query.Where(p => p.MotherId == personId || p.FatherId == personId);
        Query.Include(p => p.Events).ThenInclude(pe => pe.Event);
    }
}