using LandWin.Venues.DataCollection.Repositories;
using LandWin.Venues.DataUpdate.Commands;
using LandWin.Venues.DataUpdate.Services.ProcessHandler;
using LandWin.Venues.Domain.Dapper.Repositories;
using log4net;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataUpdate.Services.MessageHandler
{
    public class ReceivedCatalogMessageHandler : IMessageHandler<UpdateMerchantProduct>
    {
        private IProductUpdateHandler _productUpdateHandler;
        private IProductLogRepository _productLogRepository;
        private IVenueProductRepository _venueProductRepository;

        private static readonly ILog _log = LogManager.GetLogger(typeof(ReceivedCatalogMessageHandler));

        public ReceivedCatalogMessageHandler(IProductUpdateHandler productUpdateHandler, IProductLogRepository productLogRepository, IVenueProductRepository venueProductRepository )
        {
            if (productUpdateHandler == null) throw new ArgumentNullException("productUpdateHandler");
            if (productLogRepository == null) throw new ArgumentNullException("productLogRepository");
            if (venueProductRepository == null) throw new ArgumentNullException("venueProductRepository");

            _venueProductRepository = venueProductRepository;
            _productUpdateHandler = productUpdateHandler;
            _productLogRepository = productLogRepository;
        }

        public void Handle(UpdateMerchantProduct message)
        {

            var catalogs = _venueProductRepository.GetCatalogs(message.GroupId);

            if (catalogs == null) return;

            foreach (var item in catalogs)
            {

                var productlog = _productLogRepository.GetProductLog(item.CatalogId);

                if (productlog == null) return;

                _log.DebugFormat("Load Catalog {0}", item.CatalogId);



        
                foreach (var product in productlog.Catalog.products)
                {

                    var entity = _venueProductRepository.GetProduct(product.part_number);
                    if (entity == null)
                    {
                        _productUpdateHandler.InsertProduct(product, productlog.Id);
                    }
                    else
                    {
                        _productUpdateHandler.UpdateProduct(product, entity, productlog.Id);
                    }
                }
            }

        }
    }
}
