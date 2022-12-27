using ArborFamiliae.Shared.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

namespace ArborFamiliae.Data;

public class ArborRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    private ArborFamiliaeContext _context;
    private ISequenceGeneratorService _sequenceGeneratorService;
    
    public ArborRepository(ArborFamiliaeContext dbContext, ISequenceGeneratorService sequenceGeneratorService) : base(dbContext)
    {
        _context = dbContext;
        _sequenceGeneratorService = sequenceGeneratorService;
    }

    public ArborRepository(
        ArborFamiliaeContext dbContext,
        ISpecificationEvaluator specificationEvaluator, ISequenceGeneratorService sequenceGeneratorService) : base(dbContext, specificationEvaluator)
    {
        _context = dbContext;
        _sequenceGeneratorService = sequenceGeneratorService;
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = new CancellationToken()
    )
    {
        foreach (var entry in _context.ChangeTracker.Entries())
        {
            if (entry.Entity is IHasSequence)
            {
                IHasSequence? model = entry.Entity as IHasSequence;
                model.SetSequence(await _sequenceGeneratorService.GenerateSequence(model.SequenceType));
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
