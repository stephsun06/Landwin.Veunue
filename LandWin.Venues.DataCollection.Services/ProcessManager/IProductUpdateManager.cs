using LandWin.Venues.DataCollection.Entities;
using LandWin.Venues.Domain.Dapper.Entities;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Services.ProcessManager
{
    public interface IProductUpdateManager
    {
         void  InsertOrUpdate(Product product, string groupId);
        //void UpdateProduct(Product product, VenueProduct orgianl, string catalogId);
        //void InsertProduct(Product product, string catalogId);
    }
}
