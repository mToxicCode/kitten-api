using System.Threading;
using KittenApi.DataLayer.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace KittenApi.DataLayer.Utils;

public class DbConnectionFactory : IDbConnectionsFactory.IDbConnectionFactory
{
    private readonly HttpCancellationTokenAccessor _cancellationTokenAccessor;
    private readonly IConfiguration _configuration;

    public DbConnectionFactory(
        HttpCancellationTokenAccessor cancellationTokenAccessor,
        IConfiguration configuration)
    {
        _cancellationTokenAccessor = cancellationTokenAccessor;
        _configuration = configuration;
    }

    public DatabaseWrapper CreateDatabase(CancellationToken? cancellationToken = default)
        => new(
            new NpgsqlConnection(_configuration.GetPostgresConnectionString()),
            cancellationToken ?? _cancellationTokenAccessor.Token);
}