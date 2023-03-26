﻿using ArborFamiliae.Data;
using ArborFamiliae.Data.Mysql;
using ArborFamiliae.Services.IntegrationTests.Fixtures;
using Bogus;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Respawn;
using Respawn.Graph;
using Testcontainers.MySql;

namespace ArborFamiliae.Services.IntegrationTests;

[SetUpFixture]
public class TestingSetup
{
    private static IServiceScopeFactory? _scopeFactory;
    private static Respawner _respawner;
    private static string _connString;

    private static readonly MySqlContainer _dbContainer = new MySqlBuilder()
        .WithDatabase("arbor_test")
        .WithUsername("arbor")
        .WithPassword("arbor")
        .Build();

    [OneTimeTearDown]
    public async Task RunAfterAllTests()
    {
        await _dbContainer.DisposeAsync();
    }

    [OneTimeSetUp]
    public async Task RunBeforeAnyTests()
    {
        Randomizer.Seed = new Random(8573497);

        await _dbContainer.StartAsync();
        while (_dbContainer.State != TestcontainersStates.Running)
        {
            Thread.Sleep(50);
        }
        _connString = _dbContainer.GetConnectionString();

        var services = new ServiceCollection();
        services.RegisterServices();
        services.AddDbContextFactory<ArborFamiliaeContext>(options =>
        {
            var provider = services.BuildServiceProvider();
            options.UseMySql(
                _connString,
                ServerVersion.AutoDetect(_connString),
                b =>
                {
                    b.MigrationsAssembly(typeof(MySqlMarker).Assembly.FullName);
                    b.EnableRetryOnFailure();
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
            if (!db.Database.CanConnect())
            {
                throw new Exception("Database not reachable");
            }
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        using (var conn = new MySqlConnection(_connString))
        {
            await conn.OpenAsync();
            _respawner = await Respawner.CreateAsync(
                conn,
                new RespawnerOptions()
                {
                    TablesToIgnore = new Table[] { "__EFMigrationsHistory" },
                    SchemasToInclude = new[] { "arbor_test" },
                    DbAdapter = DbAdapter.MySql
                }
            );
        }
    }

    public static async Task ResetState()
    {
        using (var conn = new MySqlConnection(_connString))
        {
            await conn.OpenAsync();

            await _respawner.ResetAsync(conn);
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
