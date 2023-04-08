using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class FamilyByArborIdSpecification : SingleResultSpecification<Family>
{
    public FamilyByArborIdSpecification(string arborId)
    {

        Query.Where(f => f.ArborId == arborId);
        
        Query.Include(f => f.Father).ThenInclude(f => f.Names).ThenInclude(f => f.Surnames);
        Query.Include(f => f.Father).ThenInclude(f => f.Events).ThenInclude(f => f.Event);
        Query.Include(f => f.Father).ThenInclude(f => f.Gender);
        Query.Include(f => f.Mother).ThenInclude(f => f.Names).ThenInclude(f => f.Surnames);
        Query.Include(f => f.Mother).ThenInclude(f => f.Events).ThenInclude(f => f.Event);
        Query.Include(f => f.Mother).ThenInclude(f => f.Gender);
        
        Query
            .Include(f => f.Children)
            .ThenInclude(c => c.Child)
            .ThenInclude(c => c.Events)
            .ThenInclude(e => e.Event);
        Query
            .Include(f => f.Children)
            .ThenInclude(c => c.Child)
            .ThenInclude(c => c.Names)
            .ThenInclude(e => e.Surnames);

    }
}