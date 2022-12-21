using ArborFamiliae.Data;
using ArborFamiliae.Data.Mysql;
using ArborFamiliae.Forms.Persons;
using ArborFamiliae.Models;
using ArborFamiliae.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArborFamiliae
{
    public class ServiceContext
    {

        public static IServiceProvider ServiceProvider { get; set; }  

        public static void BuildServices(FamilyTreeDatabase database)
        {
            var builder = new HostBuilder();
            builder.ConfigureServices((hostcontext, services) =>
            {
                RegisterForms(services);
                RegisterServices(services);

                if (database.DatabaseType == Provider.MySql.Name)
                {
                    services.RegisterMySqlContext(database.Server, database.Username, database.Password, database.Database);
                }

            });

            var host = builder.Build();
            ServiceProvider = host.Services;

            using (var serviceScope = ServiceProvider.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetRequiredService<ArborFamiliaeContext>();
                ArborFamiliaeContext.InitializeAsync(db);
            }

        }

        private static void RegisterForms(IServiceCollection services)
        {
            services.AddScoped<ArborFamiliaeMainForm>();
            services.AddTransient<PersonListForm>();
            services.AddTransient<AddEditPersonForm>();

            
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.RegisterServices();
        }
    }
}
