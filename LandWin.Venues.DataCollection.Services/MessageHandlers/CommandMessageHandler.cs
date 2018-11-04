using LandWin.Venues.DataCollection.Commands;
using LandWin.Venues.DataCollection.Repositories;
using LandWin.Venues.DataCollection.Services.Infra;
using LandWin.Venues.DataCollection.Services.ProcessManager;
using LandWin.Venues.Domain.Dapper;
using LandWin.Venues.Domain.Dapper.Repositories;
using log4net;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Services.MessageHandlers
{
    public class CommandMessageHandler : IMessageHandler<SyncProduct>
    {
        private IDataCollectionManager _dataCollectionManger;

        private IProductUpdateManager _productUpdateManager;
        private IProductLogRepository _productLogRepository;

        private static readonly ILog _log = LogManager.GetLogger(typeof(CommandMessageHandler));

        public CommandMessageHandler(IDataCollectionManager dataCollectionManager , IProductLogRepository productLogRepository ,IProductUpdateManager productUpdateManager)
        {

            if (dataCollectionManager == null) throw new ArgumentNullException("dataCollectionManager");
            if (productUpdateManager == null) throw new ArgumentNullException("dbConnectionFactory");

            _dataCollectionManger = dataCollectionManager;
            _productUpdateManager = productUpdateManager;
            _productLogRepository = productLogRepository;
        }

        public void Handle(SyncProduct message)
        {
            _log.DebugFormat("Received Message : Merchant {0}", message.MerchantName);

            //string groupId = _dataCollectionManger.Run(message.MerchantName);

            var catalogs = _productLogRepository.GetProductLog()

        }

        private void UpdateProduct()
        {
            var catalogs = _productLogRepository.GetCatalog(groupId);

            if (catalogs == null) return;

            foreach (var item in catalogs)
            {
                
                _log.DebugFormat("Load Catalog {0}", item.Id);

                foreach (var product in item.Catalog.products)
                {
                    _productUpdateManager.InsertOrUpdate(product, groupId);
                }
            }
        }
    }
}
