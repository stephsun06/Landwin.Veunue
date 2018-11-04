using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;
using System.Net;


namespace TaskSchedule.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // A simple source for demonstration purposes. Modify this path as necessary.
          
             List<string> listOfUrl = new List<string>();

             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/s/t/stretch_liquid_16oz_front_preview.jpeg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/s/t/stretch_liquid_3.38oz_front_preview.jpeg");
             listOfUrl.Add("http://bergdorfgoodman.scene7.com/is/image/bergdorfgoodman/BGD2U4T_3Y_m?&wid=400&height=500");
             listOfUrl.Add("http://bergdorfgoodman.scene7.com/is/image/bergdorfgoodman/BGD2U4T_0E_m?&wid=400&height=500");
             listOfUrl.Add("https://cdn.bandier.com/media/catalog/product/t/e/techloompro-rosegold-parchment-1_1.jpg");
             listOfUrl.Add("https://cdn.bandier.com/media/catalog/product/t/e/techloomphantom-black-speckle-1_1_1.jpg");
             listOfUrl.Add("https://cdn.bandier.com/media/catalog/product/b/a/ba4c035amd2-white_049.jpg");
             listOfUrl.Add("https://cdn.bandier.com/media/catalog/product/w/s/wspblz4-charcoal_red_006.jpg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/4/4/4455bpu-black_1.jpg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/4/4/4455pnk-pink_1.jpg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/4/5/454746-015-phslh000-2000.jpg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/4/5/454746-900_1.jpg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/4/s/4sbbj-ban-nero_moonlight_1_1.jpg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/4/s/4sbbj-ban-nero_silver_1_1.jpg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/5/0/5041lev-velvet_068.jpg");
             listOfUrl.Add("https://d36jqx3zlr926x.cloudfront.net/media/catalog/product/5/0/5048trv-black_velvet_012.jpg");
            // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            // Be sure to add a reference to System.Drawing.dll.

             Parallel.ForEach(
                 listOfUrl, new ParallelOptions { MaxDegreeOfParallelism = 3 },
                 webpage =>
                 {
                     using (WebClient webClient = new WebClient())
                     {
                         var watch = System.Diagnostics.Stopwatch.StartNew();

                         byte[] data = webClient.DownloadData(webpage);
                         using (MemoryStream imageData = new MemoryStream(data))
                         {
                             Console.WriteLine(imageData.Length + " bytes received " + webpage);
                         }

                         watch.Stop();
                         Console.WriteLine("Total Execution Time :{0} {1}", watch.ElapsedMilliseconds, webpage);
                     }      

                 }
                );


            // Keep the console window open in debug mode.
            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
