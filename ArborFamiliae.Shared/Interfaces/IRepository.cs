using System.Threading.Tasks;
using Ardalis.Specification;

namespace ArborFamiliae.Shared.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
        Task ResetCache();
    }
}
