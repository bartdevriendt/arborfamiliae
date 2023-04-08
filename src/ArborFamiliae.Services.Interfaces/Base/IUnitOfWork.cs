using ArborFamiliae.Services.Interfaces.Genealogy;

namespace ArborFamiliae.Services.Interfaces.Base;

public interface IUnitOfWork : IDisposable
{
    IPersonRepository Person { get; }
    IEventRepository Event { get; }
    IPlaceRepository Place { get; }
    IFamilyRepository Family { get; }
    IGenderRepository Gender { get; }
    int Save();
}
