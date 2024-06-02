using ArborFamiliae.Data;
using ArborFamiliae.Data.InternalModels;
using ArborFamiliae.Data.Mysql;
using ArborFamiliae.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace ArborFamiliae.Services.Common;

public class ArborContextFactory : IDbContextFactory<ArborFamiliaeContext>
{
    private ILoggerFactory _loggerFactory;

    public ArborContextFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public ArborFamiliaeContext CreateDbContext()
    {
        var config = new DbContextOptionsBuilder();
        config.UseLazyLoadingProxies();
        config.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        config.EnableSensitiveDataLogging();
        config.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
        config.UseLoggerFactory(_loggerFactory);
        
        if (FamilyTreeDatabase.CurrentDatabase != null)
        {
                    
            if(FamilyTreeDatabase.CurrentDatabase.DatabaseType == "MySql"  ) {   
                var builder = new MySqlConnector.MySqlConnectionStringBuilder();
                builder.Database = FamilyTreeDatabase.CurrentDatabase.Database;
                builder.UserID = FamilyTreeDatabase.CurrentDatabase.Username;
                builder.Password = FamilyTreeDatabase.CurrentDatabase.Password;
                builder.Server = FamilyTreeDatabase.CurrentDatabase.Server;

                config.UseMySql(
                    builder.ConnectionString,
                    ServerVersion.AutoDetect(builder.ConnectionString),
                    x => { x.MigrationsAssembly(typeof(DependencyInjectionMySql).Assembly.GetName().Name); }

                );

                
            }
            else if(FamilyTreeDatabase.CurrentDatabase.DatabaseType == "Sqlite"  ) {   
                var builder = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder();
                builder.DataSource = FamilyTreeDatabase.CurrentDatabase.FilePath;
                config.UseSqlite(builder.ConnectionString, x => { x.MigrationsAssembly(typeof(SqliteMarker).Assembly.GetName().Name); });
            }
        }

        return new ArborFamiliaeContext(config.Options);

    }
}