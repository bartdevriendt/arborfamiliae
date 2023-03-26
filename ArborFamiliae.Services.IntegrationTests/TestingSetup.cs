using ArborFamiliae.Data;
using ArborFamiliae.Data.Sqlite;
using ArborFamiliae.Services.IntegrationTests.Fixtures;
using Bogus;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using Respawn.Graph;

namespace ArborFamiliae.Services.IntegrationTests;

[SetUpFixture]
public class TestingSetup
{
    private static IServiceScopeFactory? _scopeFactory;
    private static Respawner _respawner;
    private static string _connString;

    private static string _dbPath = Path.GetTempPath() + "test_arbor.sqlite";

    [OneTimeTearDown]
    public async Task RunAfterAllTests()
    {
        try
        {
            File.Delete(_dbPath);
        }
        catch (Exception ex) { }
    }

    [OneTimeSetUp]
    public async Task RunBeforeAnyTests()
    {
        Randomizer.Seed = new Random(8573497);

        var builder = new SqliteConnectionStringBuilder();
        builder.DataSource = _dbPath;
        _connString = builder.ConnectionString;

        var services = new ServiceCollection();
        services.RegisterServices();
        services.AddDbContextFactory<ArborFamiliaeContext>(options =>
        {
            var provider = services.BuildServiceProvider();

            options.UseSqlite(
                _connString,
                b =>
                {
                    b.MigrationsAssembly(typeof(SqliteMarker).Assembly.FullName);
                }
            );

            options.EnableSensitiveDataLogging();
            options.UseLazyLoadingProxies();
        });

        _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

        using (var scope = _scopeFactory.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ArborFamiliaeContext>();
            if (!File.Exists(_dbPath))
            {
                db.Database.EnsureCreated();
            }
            if (!db.Database.CanConnect())
            {
                throw new Exception("Database not reachable");
            }
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }

    public static async Task ResetState()
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ArborFamiliaeContext>();

            db.Database.EnsureCreated();

            if (!db.Database.CanConnect())
            {
                throw new Exception("Database not reachable");
            }

            await db.PersonEvents.ExecuteDeleteAsync();
            await db.Sequences.ExecuteDeleteAsync();
            await db.FamilyChildren.ExecuteDeleteAsync();
            await db.Families.ExecuteDeleteAsync();
            await db.Events.ExecuteDeleteAsync();
            await db.Persons.ExecuteDeleteAsync();
            await db.Places.ExecuteDeleteAsync();
            await db.Genders.ExecuteDeleteAsync();
        }
    }

    public static IServiceScopeFactory GetScopeFactory()
    {
        return _scopeFactory;
    }

    public static ArborFamiliaeContext GetDbContext()
    {
        var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetService<ArborFamiliaeContext>();
        return context;
    }

    public static T GetService<T>()
    {
        var scope = _scopeFactory.CreateScope();
        return scope.ServiceProvider.GetService<T>();
    }

    public static void SeedData()
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ArborFamiliaeContext>();
            context.SeedBasicData();
        }
    }
}
