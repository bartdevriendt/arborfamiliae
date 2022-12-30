using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Sequences;

public class SequenceGeneratorService : ISequenceGeneratorService
{
    private ArborFamiliaeContext _context;

    public SequenceGeneratorService(ArborFamiliaeContext context)
    {
        _context = context;
    }

    public async Task<int> GenerateSequence(string type)
    {

        var sequence = _context.Sequences.FirstOrDefault(x => x.SequenceType == type);

        if (sequence == null)
        {
            sequence = new Sequence();
            sequence.Id = Guid.NewGuid();
            sequence.SequenceType = type;
            sequence.NextValue = 1;
            _context.Sequences.Add(sequence);
        }

        int result = sequence.NextValue;
        sequence.NextValue += 1;

        await _context.SaveChangesAsync();

        return result;
    }
}
