using LandWin.Venues.DataCollection.Entities;
using LandWin.Venues.Domain.Dapper.Entities;

namespace LandWin.Venues.DataUpdate.Services.ProcessHandler
{
    public interface IProductUpdateHandler
    {
        void UpdateProduct(Product product , VenueProduct orgianl , string catalogId);
        void InsertProduct(Product product , string catalogId);
    }
}
