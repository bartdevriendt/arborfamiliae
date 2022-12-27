using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Specifications;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Sequences;

public class SequenceGeneratorService : ISequenceGeneratorService
{
    private ArborRepository<Sequence> _sequenceRepository;

    public SequenceGeneratorService(ArborRepository<Sequence> sequenceRepository)
    {
        _sequenceRepository = sequenceRepository;
    }

    public async Task<int> GenerateSequence(string type)
    {
        var sequence = await _sequenceRepository.FirstOrDefaultAsync(
            new SequenceSpecification(type)
        );

        if (sequence == null)
        {
            sequence = new Sequence();
            sequence.Id = Guid.NewGuid();
            sequence.SequenceType = type;
            sequence.NextValue = 1;
            await _sequenceRepository.AddAsync(sequence);
        }

        int result = sequence.NextValue;
        sequence.NextValue += 1;

        await _sequenceRepository.SaveChangesAsync();

        return result;
    }
}
