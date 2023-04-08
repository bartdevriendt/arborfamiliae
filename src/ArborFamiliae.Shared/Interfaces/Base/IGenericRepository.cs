using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace ArborFamiliae.Shared.Interfaces.Base;

public interface IGenericRepository<T>
    where T : class
{
    T GetById(Guid id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    T Add(T entity);
    IEnumerable<T> AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);

    // async functions

    Task<T?> FirstOrDefaultAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    );

    Task<TResult?> FirstOrDefaultAsync<TResult>(
        ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = default
    );

    Task<T?> SingleOrDefaultAsync(
        ISingleResultSpecification<T> specification,
        CancellationToken cancellationToken = default
    );

    Task<TResult?> SingleOrDefaultAsync<TResult>(
        ISingleResultSpecification<T, TResult> specification,
        CancellationToken cancellationToken = default
    );

    Task<List<T>> ListAsync(CancellationToken cancellationToken = default);

    Task<List<T>> ListAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    );

    Task<List<TResult>> ListAsync<TResult>(
        ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = default
    );

    Task<int> CountAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    );

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
}
