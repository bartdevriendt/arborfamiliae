using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArborFamiliae.Data.Mysql
{
    public static class DependencyInjection
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
                config.UseMySql(
                    builder.ConnectionString,
                    ServerVersion.AutoDetect(builder.ConnectionString),
                    x =>
                    {
                        x.MigrationsAssembly(typeof(DependencyInjection).Assembly.GetName().Name);
                    }
                );
            });
        }
    }
}
