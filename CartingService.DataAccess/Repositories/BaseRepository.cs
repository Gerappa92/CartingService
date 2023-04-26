using CartingService.DataAccess.Options;
using LiteDB;
using Microsoft.Extensions.Options;

namespace CartingService.DataAccess.Repositories;

public class BaseRepository
{
    private readonly ConnectionString _connectionString;

    public BaseRepository(IOptions<DataAccessOptions> options)
    {
        var connectionString = options.Value.ConnectionString ?? throw new ArgumentNullException(nameof(options.Value.ConnectionString));
        _connectionString = new ConnectionString(connectionString);
    }

    protected LiteDatabase GetDatabase()
    {
        return new LiteDatabase(_connectionString);
    }
}