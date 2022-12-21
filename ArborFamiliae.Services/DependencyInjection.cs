using ArborFamiliae.Services.Common;
using Microsoft.Extensions.DependencyInjection;

namespace ArborFamiliae.Services
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.Scan(scan => scan.FromAssemblyOf<ITransient>()
                .AddClasses(classes => classes.AssignableTo<ITransient>())
                    .AsSelf()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IScoped>())
                    .AsSelf()
                    .WithScopedLifetime()
            );
                

            return services;
        }

    }
}