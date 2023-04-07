using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class PlaceByArborIdSpecification : SingleResultSpecification<Place>
{
    public PlaceByArborIdSpecification(string arborId)
    {
        Query.Where(p => p.ArborId == arborId);
    }
}