using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace ArborFamiliae.Data.Mysql
{
    public static class DependencyInjectionMySql
    {
        public static void RegisterMySqlContext(
            this IServiceCollection serviceCollection,
            string server,
            string username,
            string password,
            string database
        )
        {
            var builder = new MySqlConnector.MySqlConnectionStringBuilder();
            builder.Database = database;
            builder.UserID = username;
            builder.Password = password;
            builder.Server = server;

            serviceCollection.AddDbContext<ArborFamiliaeContext>(config =>
            {
                config.UseLazyLoadingProxies();
                config.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                config.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
                config.UseMySql(
                    builder.ConnectionString,
                    ServerVersion.AutoDetect(builder.ConnectionString),
                    x =>
                    {
                        x.MigrationsAssembly(typeof(DependencyInjectionMySql).Assembly.GetName().Name);
                        
                    }
                    
                );
            }, ServiceLifetime.Transient);
        }
    }
}
