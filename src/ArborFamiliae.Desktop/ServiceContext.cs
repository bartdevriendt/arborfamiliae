using ArborFamiliae.Data;
using ArborFamiliae.Data.Mysql;
using ArborFamiliae.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArborFamiliae.Data.InternalModels;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ArborFamiliae
{
    public class ServiceContext
    {

        public static IServiceProvider ServiceProvider { get; set; }  

        public static void BuildServices()
        {
            var builder = new HostBuilder();
            builder.ConfigureServices((hostcontext, services) =>
            {
                RegisterServices(services);

                // if (database.DatabaseType == Provider.MySql.Name)
                // {
                //     services.RegisterMySqlContext(database.Server, database.Username, database.Password, database.Database);
                // }

                RegisterDatabase(services);
                
            });

            var host = builder.Build();
            ServiceProvider = host.Services;
            ServiceContainer.Default.RegisterService(ServiceContext.ServiceProvider);
            // using (var serviceScope = ServiceProvider.CreateScope())
            // {
            //     var db = serviceScope.ServiceProvider.GetRequiredService<ArborFamiliaeContext>();
            //     ArborFamiliaeContext.InitializeAsync(db);
            // }

        }

        private static void RegisterDatabase(IServiceCollection services)
        {
            services.AddDbContextFactory<ArborFamiliaeContext>(config =>
            {
                config.UseLazyLoadingProxies();
                config.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                
                config.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.MultipleCollectionIncludeWarning));

                if (FamilyTreeDatabase.CurrentDatabase != null)
                {
                    
                    if(FamilyTreeDatabase.CurrentDatabase.DatabaseType == Provider.MySql.Name) {
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
            });
        }
        
        private static void RegisterServices(IServiceCollection services)
        {
            services.RegisterServices();
        }
    }
}
