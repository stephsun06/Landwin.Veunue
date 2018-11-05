using LandWin.Venues.Domain.Dapper.Repositories;
using System;
using System.Data;

namespace LandWin.Venues.Domain.Dapper
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        void Begin(IsolationLevel isolation = IsolationLevel.ReadUncommitted);
        void Commit();
        void Rollback();
        IDbConnection GetActiveConnection();
        IDbTransaction GetActiveTransaction();
    }
}

