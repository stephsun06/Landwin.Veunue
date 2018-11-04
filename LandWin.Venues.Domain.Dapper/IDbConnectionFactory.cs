
using System.Data;

namespace LandWin.Venues.Domain.Dapper
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetOpenConnection();
        string GetConnectionString();
    }
}
