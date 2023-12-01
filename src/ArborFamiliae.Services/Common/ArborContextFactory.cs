using ArborFamiliae.Data;
using ArborFamiliae.Data.InternalModels;
using ArborFamiliae.Data.Mysql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ArborFamiliae.Services.Common;

public class ArborContextFactory : IDbContextFactory<ArborFamiliaeContext>
{
    public ArborFamiliaeContext CreateDbContext()
    {
        var config = new DbContextOptionsBuilder();
        config.UseLazyLoadingProxies();
        config.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                
        config.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.MultipleCollectionIncludeWarning));

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
        }

        return new ArborFamiliaeContext(config.Options);

    }
}