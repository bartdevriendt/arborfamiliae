using ArborFamiliae.Data.Models;
using Ardalis.Specification;

namespace ArborFamiliae.Services.Specifications;

public class SequenceSpecification : Specification<Sequence>
{
    public SequenceSpecification(string sequenceType)
    {
        Query.Where(s => s.SequenceType == sequenceType);
    }
}
