using System.Threading.Tasks;
using Ardalis.Specification;

namespace ArborFamiliae.Shared.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
        Task ResetCache();
    }
}
