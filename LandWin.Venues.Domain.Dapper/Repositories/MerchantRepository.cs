using LandWin.Venues.Domain.Dapper.Entities;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System;

namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public class MerchantRepository : DapperRepository, IMerchantRepository
    {
        public MerchantRepository(IDbTransaction unitOfWork) : base(unitOfWork) { }
        

        public IEnumerable<Merchant> GetMerchants()
        {
            return Connection.Query<Merchant>("GetMerchants", commandType: CommandType.StoredProcedure);
        }

        public void InsertCatalogLog(string id , DateTime receivdDateTime ,string merchantName ,string groupId)
        {
            if (Connection.State == ConnectionState.Closed) Connection.Open();
            var p = new DynamicParameters(new
            {
                CatalogId = id,
                ReceivedDate = receivdDateTime,
                MerchantName = merchantName,
                GroupId = groupId
            });

            
            SqlExecute("InsertCatalogLog", p , true);
            

        }
    }
}
