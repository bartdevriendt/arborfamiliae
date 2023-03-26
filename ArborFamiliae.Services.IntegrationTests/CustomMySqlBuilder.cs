using Docker.DotNet.Models;
using DotNet.Testcontainers;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Testcontainers.MySql;

namespace ArborFamiliae.Services.IntegrationTests;

public sealed class CustomMySqlBuilder
    : ContainerBuilder<CustomMySqlBuilder, MySqlContainer, MySqlConfiguration>
{
    public const string MySqlImage = "amd64/mysql:8.0";

    public const ushort MySqlPort = 3306;

    public const string DefaultDatabase = "mysql";

    public const string DefaultUsername = "mysql";

    public const string DefaultPassword = "mysql";

    /// <summary>
    /// Initializes a new instance of the <see cref="MySqlBuilder" /> class.
    /// </summary>
    public CustomMySqlBuilder()
        : this(new MySqlConfiguration())
    {
        DockerResourceConfiguration = Init().DockerResourceConfiguration;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MySqlBuilder" /> class.
    /// </summary>
    /// <param name="resourceConfiguration">The Docker resource configuration.</param>
    private CustomMySqlBuilder(MySqlConfiguration resourceConfiguration)
        : base(resourceConfiguration)
    {
        DockerResourceConfiguration = resourceConfiguration;
    }

    /// <inheritdoc />
    protected override MySqlConfiguration DockerResourceConfiguration { get; }

    /// <summary>
    /// Sets the MySql database.
    /// </summary>
    /// <param name="database">The MySql database.</param>
    /// <returns>A configured instance of <see cref="MySqlBuilder" />.</returns>
    public CustomMySqlBuilder WithDatabase(string database)
    {
        return Merge(DockerResourceConfiguration, new MySqlConfiguration(database: database))
            .WithEnvironment("MYSQL_DATABASE", database);
    }

    /// <summary>
    /// Sets the MySql username.
    /// </summary>
    /// <param name="username">The MySql username.</param>
    /// <returns>A configured instance of <see cref="MySqlBuilder" />.</returns>
    public CustomMySqlBuilder WithUsername(string username)
    {
        return Merge(DockerResourceConfiguration, new MySqlConfiguration(username: username))
            .WithEnvironment(
                "MYSQL_USER",
                "root".Equals(username, StringComparison.OrdinalIgnoreCase)
                    ? string.Empty
                    : username
            );
    }

    /// <summary>
    /// Sets the MySql password.
    /// </summary>
    /// <param name="password">The MySql password.</param>
    /// <returns>A configured instance of <see cref="MySqlBuilder" />.</returns>
    public CustomMySqlBuilder WithPassword(string password)
    {
        return Merge(DockerResourceConfiguration, new MySqlConfiguration(password: password))
            .WithEnvironment("MYSQL_PASSWORD", password)
            .WithEnvironment("MYSQL_ROOT_PASSWORD", password);
    }

    /// <inheritdoc />
    public override MySqlContainer Build()
    {
        Validate();

        // By default, the base builder waits until the container is running. However, for MySql, a more advanced waiting strategy is necessary that requires access to the configured database, username and password.
        // If the user does not provide a custom waiting strategy, append the default MySql waiting strategy.
        var mySqlBuilder =
            DockerResourceConfiguration.WaitStrategies.Count() > 1
                ? this
                : WithWaitStrategy(
                    Wait.ForUnixContainer()
                        .AddCustomWaitStrategy(new WaitUntil(DockerResourceConfiguration))
                );
        return new MySqlContainer(
            mySqlBuilder.DockerResourceConfiguration,
            TestcontainersSettings.Logger
        );
    }

    /// <inheritdoc />
    protected override CustomMySqlBuilder Init()
    {
        return base.Init()
            .WithImage(MySqlImage)
            .WithPortBinding(MySqlPort, true)
            .WithDatabase(DefaultDatabase)
            .WithUsername(DefaultUsername)
            .WithPassword(DefaultPassword);
    }

    /// <inheritdoc />
    protected override void Validate()
    {
        base.Validate();

        _ = Guard
            .Argument(
                DockerResourceConfiguration.Username,
                nameof(DockerResourceConfiguration.Username)
            )
            .NotNull()
            .NotEmpty();

        _ = Guard
            .Argument(
                DockerResourceConfiguration.Password,
                nameof(DockerResourceConfiguration.Password)
            )
            .NotNull()
            .NotEmpty();
    }

    /// <inheritdoc />
    protected override CustomMySqlBuilder Clone(
        IResourceConfiguration<CreateContainerParameters> resourceConfiguration
    )
    {
        return Merge(DockerResourceConfiguration, new MySqlConfiguration(resourceConfiguration));
    }

    /// <inheritdoc />
    protected override CustomMySqlBuilder Clone(IContainerConfiguration resourceConfiguration)
    {
        return Merge(DockerResourceConfiguration, new MySqlConfiguration(resourceConfiguration));
    }

    /// <inheritdoc />
    protected override CustomMySqlBuilder Merge(
        MySqlConfiguration oldValue,
        MySqlConfiguration newValue
    )
    {
        return new CustomMySqlBuilder(new MySqlConfiguration(oldValue, newValue));
    }

    /// <inheritdoc cref="IWaitUntil" />
    private sealed class WaitUntil : IWaitUntil
    {
        private readonly IList<string> _command;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaitUntil" /> class.
        /// </summary>
        /// <param name="configuration">The container configuration.</param>
        public WaitUntil(MySqlConfiguration configuration)
        {
            _command = new List<string>
            {
                "mysql",
                "--protocol=TCP",
                $"--port={MySqlPort}",
                $"--user={configuration.Username}",
                $"--password={configuration.Password}",
                configuration.Database,
                "--wait",
                "--silent",
                "--execute=SELECT 1;"
            };
        }

        /// <inheritdoc />
        public async Task<bool> UntilAsync(IContainer container)
        {
            var execResult = await container.ExecAsync(_command).ConfigureAwait(false);

            return 0L.Equals(execResult.ExitCode);
        }
    }
}
