using System;
using System.Data;


namespace LandWin.Venus.DataGateWay.Repositories
{
    public class Repository /*: IDisposable*/
    {

        protected IDbTransaction Transaction { get; private set; }

        protected IDbConnection Connection { get { return Transaction.Connection; } }



        public Repository(IDbTransaction transaction)
        {

            Transaction = transaction;

        }
        //protected readonly IDbConnection Connection;
        //protected readonly IDbTransaction ActiveTransaction;
        //protected Repository(IUnitOfWork unitOfWork)
        //{
        //    if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
        //    ActiveTransaction = unitOfWork.GetActiveTransaction();
        //    Connection = unitOfWork.GetActiveConnection();
        //}

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            Connection.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}

