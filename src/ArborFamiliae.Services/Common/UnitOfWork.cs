using ArborFamiliae.Data;
using ArborFamiliae.Data.Models;
using ArborFamiliae.Services.Interfaces.Base;
using ArborFamiliae.Services.Interfaces.Genealogy;
using ArborFamiliae.Services.Repository;
using ArborFamiliae.Shared.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ArborFamiliae.Services.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly ArborFamiliaeContext _context;
    private readonly ISequenceGeneratorService _sequenceGeneratorService;

    public UnitOfWork(
        ArborFamiliaeContext context,
        ISequenceGeneratorService sequenceGeneratorService
    )
    {
        _context = context;
        _sequenceGeneratorService = sequenceGeneratorService;
        Person = new PersonRepository(context, SpecificationEvaluator.Default);
        Event = new EventRepository(context, SpecificationEvaluator.Default);
        Place = new PlaceRepository(context, SpecificationEvaluator.Default);
        Family = new FamilyRepository(context, SpecificationEvaluator.Default);
        Gender = new GenderRepository(context, SpecificationEvaluator.Default);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IPersonRepository Person { get; }
    public IEventRepository Event { get; }
    public IPlaceRepository Place { get; }
    public IFamilyRepository Family { get; }
    public IGenderRepository Gender { get; }

    public int Save()
    {
        IEnumerable<EntityEntry> entities = _context.ChangeTracker
            .Entries()
            .Where(t => t.Entity is IHasSequence && t.State == EntityState.Added);

        if (entities.Any())
        {
            foreach (EntityEntry entry in entities.ToList())
            {
                IHasSequence? model = entry.Entity as IHasSequence;
                if (model.NeedsSequence)
                {
                    var sequence = _context.Sequences.FirstOrDefault(
                        x => x.SequenceType == model.SequenceType
                    );

                    if (sequence == null)
                    {
                        sequence = new Sequence();
                        sequence.Id = Guid.NewGuid();
                        sequence.SequenceType = model.SequenceType;
                        sequence.NextValue = 1;
                        _context.Sequences.Add(sequence);
                    }

                    int result = sequence.NextValue;
                    sequence.NextValue += 1;

                    model.SetSequence(result);
                }
            }
        }

        return _context.SaveChanges();
    }
}
