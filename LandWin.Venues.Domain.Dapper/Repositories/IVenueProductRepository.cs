using LandWin.Venues.Domain.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public interface IVenueProductRepository
    {

        IEnumerable<CatalogLog> GetCatalogs(string groupId);
        IEnumerable<Category> GetCategories(string merchant);
        VenueProduct GetProduct(string partNumber , string merchant);
        IEnumerable<VenueProductColor> GetProductColors(long id);
        IEnumerable<VenueProductColorSize> GetProductColorSizes(long id);
        long InsertProduct(VenueProduct product);
        void InsertColor(VenueProductColor color);
        void InsertSize(VenueProductColorSize size);
        void UpdateProduct(VenueProduct product);
        void UpdateColor(VenueProductColor color);
        void DeleteColor(long colorId);
        void DeleteSize(long colorId);

    }
}
