using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class FamilyListSpecification : Specification<Family>
{
    public FamilyListSpecification(Guid? id = null)
    {
        Query.Include(f => f.Father).ThenInclude(f => f.Names).ThenInclude(f => f.Surnames);
        Query.Include(f => f.Father).ThenInclude(f => f.Events).ThenInclude(f => f.Event);
        Query.Include(f => f.Father).ThenInclude(f => f.Gender);
        Query.Include(f => f.Mother).ThenInclude(f => f.Names).ThenInclude(f => f.Surnames);
        Query.Include(f => f.Mother).ThenInclude(f => f.Events).ThenInclude(f => f.Event);
        Query.Include(f => f.Mother).ThenInclude(f => f.Gender);
        Query.Include(f => f.Children);

        if (id != null)
        {
            Query.Where(f => f.Id == id);
        }
    }
}
