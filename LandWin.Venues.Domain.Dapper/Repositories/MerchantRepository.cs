using LandWin.Venues.Domain.Dapper.Entities;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System;

namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public class MerchantRepository : DapperRepository, IMerchantRepository
    {
        public MerchantRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IEnumerable<Category> GetCategories(string merchant)
        {
            return Connection.Query<Category>("GetMerchantCategory", new { Merchant = merchant }, commandType: CommandType.StoredProcedure);
        }

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

        public int InsertMerchantCategory(string merchant, string categoryName)
        {
            var p = new DynamicParameters(new
            {
                Merchant = merchant,
                CategoryName = categoryName,
            
            });

            p.Add("@newId", DbType.Int32, direction: ParameterDirection.Output);

            Connection.Execute("InsertMerchantCategory", p, commandType: CommandType.StoredProcedure);
            return p.Get<dynamic>("newId");
        }
    }
}
