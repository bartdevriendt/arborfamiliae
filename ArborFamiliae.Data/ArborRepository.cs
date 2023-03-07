using ArborFamiliae.Shared.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ArborFamiliae.Data;

public class ArborRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    private ArborFamiliaeContext _context;
    private ISequenceGeneratorService _sequenceGeneratorService;

    public ArborRepository(
        ArborFamiliaeContext dbContext,
        ISequenceGeneratorService sequenceGeneratorService
    )
        : base(dbContext)
    {
        _context = dbContext;
        _sequenceGeneratorService = sequenceGeneratorService;
    }

    public ArborRepository(
        ArborFamiliaeContext dbContext,
        ISpecificationEvaluator specificationEvaluator,
        ISequenceGeneratorService sequenceGeneratorService
    )
        : base(dbContext, specificationEvaluator)
    {
        _context = dbContext;
        _sequenceGeneratorService = sequenceGeneratorService;
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = new CancellationToken()
    )
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
                    var sequence = await _sequenceGeneratorService.GenerateSequence(
                        model.SequenceType
                    );
                    model.SetSequence(sequence);
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
