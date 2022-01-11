using System.Threading;

namespace KittenApi.DataLayer.Utils;

public interface IDbConnectionsFactory
{
    public interface IDbConnectionFactory
    {
        DatabaseWrapper CreateDatabase(CancellationToken? cancellationToken = default);
    }
}