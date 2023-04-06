using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class FamilyEventListSpecification : SingleResultSpecification<Family>
{
    public FamilyEventListSpecification(Guid familyId)
    {
        Query.Where(f => f.Id == familyId);
        Query.Include(p => p.Events).ThenInclude(pe => pe.Event);
    }
}