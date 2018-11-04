using LandWin.Venues.Domain.Dapper.Entities;
using System;
using System.Collections.Generic;


namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public  interface IMerchantRepository
    {
        IEnumerable<Merchant> GetMerchants();
        void InsertCatalogLog(string id, DateTime receivdDateTime, string merchantName , string gourpID);
    }
}
