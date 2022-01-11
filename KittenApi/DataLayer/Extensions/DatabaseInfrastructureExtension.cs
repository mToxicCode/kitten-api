using System.Reflection;
using FluentMigrator.Runner;
using KittenApi.DataLayer.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KittenApi.DataLayer.Extensions;

public static class DatabaseInfrastructureExtension
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<UsersRepository>()
            .AddSingleton<IDbConnectionsFactory.IDbConnectionFactory, DbConnectionFactory>()
            .AddSingleton<DbExecuteWrapper>();

        return services.AddFluentMigratorCore()
            .ConfigureRunner(x
                => x.AddPostgres()
                    .WithGlobalConnectionString(configuration.GetPostgresConnectionString())
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
            .AddLogging(y => y.AddFluentMigratorConsole());
    }
}