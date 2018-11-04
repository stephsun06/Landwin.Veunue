using LandWin.Venues.DataCollection.Entities;
using System.Threading.Tasks;


namespace LandWin.Venus.DataGatewayin.Serivces.Api
{
    public interface ICatalogApiService
    {
        Task<Catalog> GetCatalog(string url);
    }
}
