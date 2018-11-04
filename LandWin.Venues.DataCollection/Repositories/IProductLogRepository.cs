using LandWin.Venues.DataCollection.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Repositories
{
    public interface IProductLogRepository
    {
        IEnumerable<ProductLog> GetCatalog(string merchant);
        ProductLog GetProductLog(string id);
        ProductLog InsertLog(ProductLog log);
        void Delete(string merchant);
    
    }
}
