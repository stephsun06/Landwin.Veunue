using Dapper;
using System;
using System.Data;
using System.Transactions;

namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public class RepositoryBase 
    {
        protected IDbTransaction Transaction { get; private set; }

        protected IDbConnection Connection { get { return Transaction.Connection; } }



        public RepositoryBase(IDbTransaction transaction)
        {

            Transaction = transaction;

        }
    }
}
