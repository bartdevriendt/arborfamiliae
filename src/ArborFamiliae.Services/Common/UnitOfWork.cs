using ArborFamiliae.Data;
using ArborFamiliae.Services.Interfaces.Base;
using ArborFamiliae.Services.Interfaces.Genealogy;
using ArborFamiliae.Services.Repository;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

namespace ArborFamiliae.Services.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly ArborFamiliaeContext _context;

    public UnitOfWork(ArborFamiliaeContext context)
    {
        _context = context;
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
        return _context.SaveChanges();
    }
}
