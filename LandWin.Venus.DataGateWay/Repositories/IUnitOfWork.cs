using System;
using System.Data;

namespace LandWin.Venus.DataGateWay.Repositories
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

