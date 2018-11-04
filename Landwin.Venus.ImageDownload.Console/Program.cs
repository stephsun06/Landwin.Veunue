using LandWin.Venus.DataGateWay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Landwin.Venus.ImageDownload.Console
{
    class Program
    {
        static void Main(string[] args)
        {

             CancellationTokenSource cts = new CancellationTokenSource();

            try
            {
                await AccessTheWebAsync();
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception)
            {
            }

            cts = null;
        }

         async Task AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();

            // Make a list of web addresses.  
            List<ImageUrl> urlList = new List<ImageUrl>();

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

            }

        }

        static async Task<int> ProcessURL(ImageUrl image, HttpClient client)
        {
            // GetAsync returns a Task<HttpResponseMessage>.   
            HttpResponseMessage response = await client.GetAsync(image.Url);

            // Retrieve the website contents from the HttpResponseMessage.  
            byte[] urlContents = await response.Content.ReadAsByteArrayAsync();

            return urlContents.Length;
        }

    }
 
}
