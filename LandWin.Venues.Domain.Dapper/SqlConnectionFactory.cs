
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LandWin.Venues.Domain.Dapper
{

    public class SqlConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetOpenConnection()
        {
            var cs = GetConnectionString();
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }

        public  string GetConnectionString()
        {
            var key = string.Format("LW_{0}", Environment.MachineName);
            try
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get connectionstring for key: " + key, ex);
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ConnectionFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }

}
