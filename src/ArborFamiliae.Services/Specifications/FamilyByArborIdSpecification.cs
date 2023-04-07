using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class FamilyByArborIdSpecification : SingleResultSpecification<Family>
{
    public FamilyByArborIdSpecification(string arborId)
    {

        Query.Where(f => f.ArborId == arborId);

    }
}