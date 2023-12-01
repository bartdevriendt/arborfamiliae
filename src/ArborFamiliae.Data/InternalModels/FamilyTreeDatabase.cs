namespace ArborFamiliae.Data.InternalModels;

public class FamilyTreeDatabase : IEquatable<FamilyTreeDatabase>
{
    public string DatabaseType { get; set; }
    public string Name { get; set; }
    public string Server { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }

    public string FilePath { get; set; }

    public bool Equals(FamilyTreeDatabase? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return DatabaseType == other.DatabaseType && Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FamilyTreeDatabase)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DatabaseType, Name);
    }
    
    public static FamilyTreeDatabase? CurrentDatabase { get; set; }
}
