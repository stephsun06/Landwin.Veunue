using Flurl;
using Flurl.Http;
using LandWin.Venues.DataCollection.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Services.Infra
{
    public class CatalogApiService : ICatalogApiService
    {
        private ISystemConfiguration _config;

        private static readonly ILog _log = LogManager.GetLogger(typeof(CatalogApiService));

        public CatalogApiService(ISystemConfiguration config) : base() 
        {
            if (config == null) throw new ArgumentNullException("config");

            _config = config;
        }

        public async Task<Catalog> GetCatalog(string url)
        {
            try
            {
                Url client = new Url(string.Format("{0}{1}",_config.DataApiUrl,url));

                client.WithHeader("Accept", "application/json");

                var result = await client.WithOAuthBearerToken(_config.ApiToken).GetJsonAsync<Catalog>();

              
                if (result == null) return null;

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
           

        }
    }
}
