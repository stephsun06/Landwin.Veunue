using Flurl;
using Flurl.Http;
using System.Configuration;


namespace LandWin.Venues.DataCollection.Services.Infra
{
     public abstract class FlurlApiService
     {
        private readonly string _baseUrl;

        protected FlurlApiService(string apiUrlKey = "webApiUrl")
        {  
            _baseUrl = ConfigurationManager.AppSettings[apiUrlKey];
        }

        protected FlurlClient Url(params string[] segments)
        {
            return _baseUrl
                .AppendPathSegments(segments)
                .WithHeader("Accept", "application/json");
        }


}
}

