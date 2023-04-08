using System.Linq.Expressions;
using ArborFamiliae.Data;
using ArborFamiliae.Shared.Interfaces.Base;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Services.Common;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    protected readonly ArborFamiliaeContext _context;
    protected readonly ISpecificationEvaluator _specificationEvaluator;

    public GenericRepository(
        ArborFamiliaeContext context,
        ISpecificationEvaluator specificationEvaluator
    )
    {
        this._context = context;
        _specificationEvaluator = specificationEvaluator;
    }

    public T Add(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }

    public IEnumerable<T> AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        return entities;
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public T GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public async Task<T?> FirstOrDefaultAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    )
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TResult?> FirstOrDefaultAsync<TResult>(
        ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = default
    )
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<T?> SingleOrDefaultAsync(
        ISingleResultSpecification<T> specification,
        CancellationToken cancellationToken = default
    )
    {
        return await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<TResult?> SingleOrDefaultAsync<TResult>(
        ISingleResultSpecification<T, TResult> specification,
        CancellationToken cancellationToken = default
    )
    {
        return await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    )
    {
        var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

        return specification.PostProcessingAction == null
            ? queryResult
            : specification.PostProcessingAction(queryResult).ToList();
    }

    public async Task<List<TResult>> ListAsync<TResult>(
        ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = default
    )
    {
        var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

        return specification.PostProcessingAction == null
            ? queryResult
            : specification.PostProcessingAction(queryResult).ToList();
    }

    public async Task<int> CountAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    )
    {
        return await ApplySpecification(specification, true).CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().CountAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    )
    {
        return await ApplySpecification(specification, true).AnyAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().AnyAsync(cancellationToken);
    }

    protected virtual IQueryable<T> ApplySpecification(
        ISpecification<T> specification,
        bool evaluateCriteriaOnly = false
    )
    {
        return _specificationEvaluator.GetQuery(
            _context.Set<T>().AsQueryable(),
            specification,
            evaluateCriteriaOnly
        );
    }

    protected virtual IQueryable<TResult> ApplySpecification<TResult>(
        ISpecification<T, TResult> specification
    )
    {
        return _specificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }
}
