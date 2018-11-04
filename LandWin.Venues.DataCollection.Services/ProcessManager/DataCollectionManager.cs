using LandWin.Venues.DataCollection.Entities;
using LandWin.Venues.DataCollection.Repositories;
using LandWin.Venues.DataCollection.Services.Infra;
using LandWin.Venues.DataUpdate.Commands;
using LandWin.Venues.Domain.Dapper;
using LandWin.Venues.Domain.Dapper.Entities;
using LandWin.Venues.Domain.Dapper.Repositories;
using log4net;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LandWin.Venues.DataCollection.Services.ProcessManager
{
    public class DataCollectionManager  : IDataCollectionManager 
    {

        private bool _IsDone;
        private bool _IsBusy;
        private Guid _groupId;
        private Queue<CatalogLog> _queue = new Queue<CatalogLog>();
   
        
        private const int FirstRunLookUpInterval = 10000;


        private ICatalogApiService _catalogApiService;
        private ISystemConfiguration _config;
        private IProductLogRepository _productLogRepository;
        private IMerchantRepository _merchantRepository;
        private IBus _bus;
   

        private readonly ILog _log = LogManager.GetLogger(typeof(DataCollectionManager));


        public DataCollectionManager(ICatalogApiService catalogApiService , ISystemConfiguration config ,IMerchantRepository merchantRepository, IProductLogRepository productLogRepository , IBus bus )
        {
            if (catalogApiService == null) throw new ArgumentNullException("catalogApiService");
           if (productLogRepository == null) throw new ArgumentNullException("productLogRepository");
            if (merchantRepository == null) throw new ArgumentNullException("merchantRepository");
            if (config == null) throw new ArgumentNullException("config");
            if (bus == null) throw new ArgumentNullException("bus");

            _merchantRepository = merchantRepository;
            _config = config;
            _catalogApiService = catalogApiService;
            _productLogRepository = productLogRepository;
            _bus = bus;
        }

        public void Run(string merchant )
        {
            var log = _merchantRepository.GetMerchants().FirstOrDefault(x => x.Name == merchant);

            if (log == null) return ;

            _groupId = new Guid();

            _log.DebugFormat("Delete Merchant {0}", merchant);

            _productLogRepository.Delete(merchant);


            _queue.Enqueue(new CatalogLog()
            {
                MerchantName = merchant ,
                Url = log.Url,
            });

            _log.DebugFormat("Done Received Data {0}", _groupId);

            while (_IsDone == false)
            {
                _log.DebugFormat("Check  {0} , {1}", _IsDone, _queue.Count());

                if (_queue.Count > 0 && _IsBusy == false)
                {

                    GetCatalog(_queue.Dequeue());

                }
                Thread.Sleep(5000);

            }

            _log.DebugFormat("Done Received Data {0}", _groupId);

        }

        private void GetCatalog(CatalogLog log)
        {
            var task = _catalogApiService.GetCatalog(log.Url);
            task.ContinueWith(x =>
            {
                _log.DebugFormat("Failed");

                log.Status = "Failed";

                _IsBusy = false;
                _IsDone = true;


            }, TaskContinuationOptions.OnlyOnFaulted);

            task.ContinueWith(t =>
            {
                var result = t.Result;
                if (result != null)
                {
                    var item = _productLogRepository.InsertLog(
                       new ProductLog()
                       {
                           MerchantName = log.MerchantName,
                           ReceivdDate = DateTime.Now,
                           Catalog = result,
                           
                       });

                    foreach(var production in result.products)
                    {
                        
                        _bus.Send(new UpdateMerchantProduct()
                        {
                            GroupId = _groupId.ToString(),
                            SKU = production.part_number,
                            MerchantName = production.merchant,
                            ID = item.Id

                        });
                    }


                    _log.DebugFormat("Next Url {0}", result.navigation.next_page_url);

                    if (!string.IsNullOrEmpty(result.navigation.next_page_url))
                    {
                        _queue.Enqueue(new CatalogLog()
                        {
                            MerchantName = log.MerchantName,
                            Url = result.navigation.next_page_url,
                        });
                    }
                    else
                    {
                        _IsDone = true;
                    }

                    return;
                }
                
               
                _IsBusy = false;
                
                
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

    }
}
