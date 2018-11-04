
using System;
using System.Data;

namespace LandWin.Venues.Domain.Dapper
{
    public class DapperUnitOfWork : IUnitOfWork 
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private bool _disposed;
    }
}
