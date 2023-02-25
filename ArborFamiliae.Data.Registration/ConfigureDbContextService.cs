using Microsoft.EntityFrameworkCore;

namespace ArborFamiliae.Data.Registration;

public class ConfigureDbContextService
{
    public static void RegisterDbContextService(
        string provider,
        string connString,
        DbContextOptionsBuilder options
    )
    {
        if (provider == "MySql")
        {
            options.UseMySql(
                connString,
                ServerVersion.AutoDetect(connString),
                x =>
                {
                    x.MigrationsAssembly(
                        typeof(ArborFamiliae.Data.Mysql.DependencyInjection).Assembly.GetName().Name
                    );
                }
            );
        }
    }
}
