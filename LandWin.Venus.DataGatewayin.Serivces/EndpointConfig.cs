using NServiceBus;
using StructureMap;
using System;
using System.Data;
using log4net.Config;
using LandWin.Venus.DataGatewayin.Serivces.Api;
using LandWin.Venus.DataGateWay;
using LandWin.Venus.DataGateWay.Repositories;
using NobelProcera.Framework.MongoDB;
using LandWin.Venues.DataCollection.Repositories;
using LandWin.Venus.DataGatewayin.Serivces.Infra;

namespace LandWin.Venus.DataGatewayin.Serivces
{
    public class EndpointConfig : IWantCustomInitialization, IConfigureThisEndpoint, AsA_Server
    {
        
        public void Init()
        {
            var container = ConfigureStructureMap();

            log4net.Config.XmlConfigurator.Configure();
     


            Configure.With()
                .DefiningCommandsAs(t =>
                {
                    return t.Namespace != null
                         && ((t.Namespace.EndsWith("Commands")
                               || (t.Namespace.EndsWith("Contract"))
                             ));
                })
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
                x.For<IMongoDbConnection>().Singleton().Use<MongoDbConnection>();
                x.For<IUnitOfWork>().Singleton().Use<DapperUnitOfWork>();
                x.For<IMongoUnitOfWork>().Singleton().Use<MongoUnitOfWork>();
                x.For<IDbConnectionFactory>().Use<SqlConnectionFactory>();
                x.For<ICatalogApiService>().Singleton().Use<CatalogApiService>();
                x.For<IProductRepository>().Use<ProductRepository>();
                x.For<ICatalogRepository>().Use<CatalogRepository>();
                x.For<ISystemConfiguration>().Singleton().Use<SystemConfiguration>();
            });
        } 
    }
}
