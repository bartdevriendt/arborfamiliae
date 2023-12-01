using ArborFamiliae.Data.InternalModels;
using ArborFamiliae.Services.Interfaces.Database;
using Newtonsoft.Json;

namespace ArborFamiliae.Services.Common;

public class FamilyTreeDatabaseService : IFamilyTreeDatabaseService
{
    public void StoreDatabase(FamilyTreeDatabase database)
    {
        var databases = LoadDatabases();
        databases.Add(database);
        SaveDatabases(databases);
    }

    public void DeleteDatabase(FamilyTreeDatabase database)
    {
        var databases = LoadDatabases();
        
        databases.Remove(database);
        SaveDatabases(databases);
    }

    private string GetDatabasesFilePath()
    {
        string folder =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            + "\\ArborFamiliae\\";
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        return folder + "databases.json";
    }

    public List<FamilyTreeDatabase> LoadDatabases()
    {
        string file = GetDatabasesFilePath();

        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<List<FamilyTreeDatabase>>(json);
        }

        return new List<FamilyTreeDatabase>();
    }

    private void SaveDatabases(List<FamilyTreeDatabase> databases)
    {
        string file = GetDatabasesFilePath();
        string json = JsonConvert.SerializeObject(databases);
        File.WriteAllText(file, json);
    }
}
