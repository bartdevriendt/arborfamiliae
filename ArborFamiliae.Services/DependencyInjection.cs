using ArborFamiliae.Data;
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
                        .AsSelf()
                        .WithTransientLifetime()
                        .AddClasses(classes => classes.AssignableTo<IScoped>())
                        .AsSelf()
                        .WithScopedLifetime()
            );

            services.AddScoped<ISequenceGeneratorService, SequenceGeneratorService>();
            services.AddScoped(typeof(IRepository<>), typeof(ArborRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ArborRepository<>));

            return services;
        }
    }
}
