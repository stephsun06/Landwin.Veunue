
using LandWin.Venues.DataCollection.Entities;
using System.Threading.Tasks;


namespace LandWin.Venues.DataCollection.Services.Infra
{
    public interface ICatalogApiService
    {
        Task<Catalog> GetCatalog(string url);
    }
}
