using ArborFamiliae.Data;
using ArborFamiliae.Services.Sequences;
using ArborFamiliae.Shared.Interfaces;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ArborFamiliae.Services.Common;

public class ArborRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    private ArborFamiliaeContext _context;
    private ISequenceGeneratorService _sequenceGeneratorService;

    public ArborRepository(IDbContextFactory<ArborFamiliaeContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _context = (ArborFamiliaeContext)Context;
        _sequenceGeneratorService = new SequenceGeneratorService(_context);
    }

    public ArborRepository(
        IDbContextFactory<ArborFamiliaeContext> dbContextFactory,
        ISpecificationEvaluator specificationEvaluator
    )
        : base(dbContextFactory.CreateDbContext(), specificationEvaluator)
    {
        _context = (ArborFamiliaeContext)Context;
        _sequenceGeneratorService = new SequenceGeneratorService(_context);
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

    public async Task ResetCache()
    {
        _context.ChangeTracker.Clear();
    }
}
