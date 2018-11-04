using NServiceBus;
using StructureMap;
using NobelProcera.Framework.MongoDB;
using LandWin.Venues.DataCollection.Repositories;
using LandWin.Venues.Domain.Dapper;
using LandWin.Venues.Domain.Dapper.Repositories;
using LandWin.Venues.DataUpdate.Services.ProcessHandler;

namespace LandWin.Venues.DataUpdate.Services
{
    public class EndPointConfig : IWantCustomInitialization, IConfigureThisEndpoint, AsA_Server
    {
        public void Init()
        {

            var container = ConfigureStructureMap();

            log4net.Config.XmlConfigurator.Configure();

            Configure.With()
                .DefiningCommandsAs(t => t.Namespace != null && (t.Namespace.EndsWith("Commands")))
                .StructureMapBuilder(container)
                .XmlSerializer()
                .DisableSecondLevelRetries()
                .DisableTimeoutManager()
                .MsmqSubscriptionStorage();
        }

        private static IContainer ConfigureStructureMap()
        {
            return new Container(x =>
            {
                x.For<IDbConnectionFactory>().Use<SqlConnectionFactory>();
                x.For<IMongoDbConnection>().Singleton().Use<MongoDbConnection>();
                x.For<IUnitOfWork>().Use<DapperUnitOfWork>();
                x.For<IMongoUnitOfWork>().Use<MongoUnitOfWork>();

                x.For<IProductLogRepository>().Use<ProductLogRepository>();

                x.For<IMerchantRepository>().Use<MerchantRepository>();
                x.For<ISystemRepository>().Use<SystemRepository>();
                x.For<IVenueProductRepository>().Use<VenueProductRepository>();

                x.For<IProductUpdateHandler>().Use<ProductUpdateHandler>();
            });
        }
    }
}