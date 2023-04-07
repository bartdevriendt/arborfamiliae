using ArborFamiliae.Data;
using ArborFamiliae.Services.Common;
using ArborFamiliae.Services.Sequences;
using ArborFamiliae.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArborFamiliae.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.Scan(
                scan =>
                    scan.FromAssemblyOf<IServicesMarker>()
                        .AddClasses(classes => classes.AssignableTo<ITransient>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                        .AddClasses(classes => classes.AssignableTo<IScoped>())
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
            );

            services.AddScoped<ISequenceGeneratorService, SequenceGeneratorService>();
            services.AddTransient(typeof(IRepository<>), typeof(ArborRepository<>));
            services.AddTransient(typeof(IReadRepository<>), typeof(ArborRepository<>));
            services.AddLocalization();
            services.AddLogging();
            return services;
        }
    }
}
