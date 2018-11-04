using LandWin.Venus.DataGateWay.Models;
using LandWin.Venus.DataGateWay.Repositories;
using LandWin.Venus.DataGatewayin.Serivces.Api;
using log4net;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LandWin.Venus.DataGatewayin.Serivces
{
    public class ImageDownloader : IWantToRunAtStartup
    {
        private static Timer _queueManagerTimer;

        private int _totalcount;
        private bool _isbusy;
        private Stack<int> queue = new Stack<int>();
        private ICatalogApiService _catalogApiService;
        private IProductRepository _productRepository;
        private readonly ILog _log = LogManager.GetLogger(typeof(DataCollectionProcess));

        private string siteUrl = "http://api.shoppable.co";

        public ImageDownloader(ICatalogApiService catalogApiService, IProductRepository productRepository)
        {
            if (catalogApiService == null) throw new ArgumentNullException("catalogApiService");

            if (productRepository == null) throw new ArgumentNullException("productRepository");

            _catalogApiService = catalogApiService;
            _productRepository = productRepository;

   //         _totalcount = _productRepository.GetTotalCount();

            queue.Push(1);

        }

        public void Run()
        {
            if (_queueManagerTimer == null)
            {
                StartScheduler();
            }

        }
        private void StartScheduler()
        {
            _queueManagerTimer = new Timer(StartSchedulerCallback, null, 0, Timeout.Infinite);

        }
        public void Stop()
        {
            throw new NotImplementedException();
        }

        private  void StartSchedulerCallback(object state)
        {
            _queueManagerTimer.Change(Timeout.Infinite, Timeout.Infinite);

            _log.DebugFormat("Image Count {0}", queue.Count);

            while (queue.Count > 0)
            {
                var urlList = _productRepository.GetImageUrl(queue.Pop(), 10000).ToList();

                 GetImage(urlList);

            }

            _queueManagerTimer.Change(8000, Timeout.Infinite);


        }



        public  async void GetImage( List<ImageUrl> urlList)
        {
            

            HttpClient client = new HttpClient();


            // ***Create a query that, when executed, returns a collection of tasks.
            IEnumerable<Task<int>> downloadTasksQuery =
                from url in urlList select ProcessURL(url, client);

            // ***Use ToList to execute the query and start the tasks. 
            List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

            // ***Add a loop to process the tasks one at a time until none remain.
            while (downloadTasks.Count > 0)
            {
                // Identify the first task that completes.
                Task<int> firstFinishedTask = await Task.WhenAny(downloadTasks);

                // ***Remove the selected task from the list so that you don't
                // process it more than once.
                downloadTasks.Remove(firstFinishedTask);

                // Await the completed task.
                int length = await firstFinishedTask;

                _log.DebugFormat("Length : {0}", length);
            }

        }


        async Task<int> ProcessURL(ImageUrl image, HttpClient client)
        {
            // GetAsync returns a Task<HttpResponseMessage>. 
            HttpResponseMessage response = await client.GetAsync(image.Url);

            // Retrieve the website contents from the HttpResponseMessage.
            byte[] urlContents = await response.Content.ReadAsByteArrayAsync();

            return urlContents.Length;
        }
    }

}

