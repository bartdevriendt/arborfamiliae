using ArborFamiliae.Data.InternalModels;
using ArborFamiliae.Shared.Interfaces;

namespace ArborFamiliae.Services.Interfaces.Database;

public interface IFamilyTreeDatabaseService : ITransient
{
    void StoreDatabase(FamilyTreeDatabase database);
    void DeleteDatabase(FamilyTreeDatabase database);
    List<FamilyTreeDatabase> LoadDatabases();
}