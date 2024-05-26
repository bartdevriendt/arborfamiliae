namespace ArborFamiliae.Hybrid.Shared.Models;

public record Provider(string Name, string Assembly)
{
    public static Provider MySql =
        new(nameof(MySql), typeof(Data.Mysql.MySqlMarker).Assembly.GetName().Name!);
    public static Provider Sqlite =
        new(nameof(Sqlite), typeof(Data.Sqlite.SqliteMarker).Assembly.GetName().Name!);
    //public static Provider Postgres = new(nameof(Postgres), typeof(Postgres.Marker).Assembly.GetName().Name!);
}
