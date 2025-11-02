using ArborFamiliae.Data.InternalModels;

namespace ArborFamiliae.CrossPlatform;

public class ConnectionStringService
{
    public static string ConnectionString { get; set; } = "";
    public static string Provider { get; set; } = "";


    public static List<FamilyTreeDatabase> GetDatabases()
    {
        var databases = new List<FamilyTreeDatabase>();
        databases.Add(new FamilyTreeDatabase()
        {
            Database = "arbor",
            DatabaseType = "MySql",
            Server = "192.168.3.11",
            Username = "arbor",
            Password = "arbor",
            Name = "Adel"
        });
        return databases;
    }
}