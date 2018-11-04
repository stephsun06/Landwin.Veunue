using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using StructureMap;
using LandWin.Venus.DataGateWay.Repositories;
using StructureMap.Configuration.DSL;
using LandWin.Venus.DataGateWay.Models;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;

namespace Lanwin.Venue.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(x =>
            {
                x.For<IUnitOfWork>().Singleton().Use<DapperUnitOfWork>();
                x.For<IDbConnectionFactory>().Use<SqlConnectionFactory>();
                x.For<IProductRepository>().Use<ProductRepository>();
            });


            var app = container.GetInstance<Application>();
            app.Run();
            Console.ReadLine();

        }

        public class ConsoleRegistry : Registry
        {
            public ConsoleRegistry()
            {
                Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            }
        }

        public class Application
        {
             IProductRepository repo;

            CancellationTokenSource cts;

            public Application(IProductRepository repository)
            {
                repo = repository;

            }

            public  void Run()
            {

                //var list = repo.GetMagentoCategory();
 
                //foreach(var item in list)
                //{
                //    string category = item.CategoryName.Replace("~","/");

                //   if(category.Split('/').Length == 2)
                //   {
                //       repo.InsertCategroy(item.Merchant, item.CategoryName);

                //       Console.WriteLine(item.CategoryName);
                //   }
                    

               // }
            }
          
        }


        public class CategoryFactory
        {
            IProductRepository _repository;

            public CategoryFactory(IProductRepository repository)
            {
                _repository = repository; 
            }

            public void Run()
            {
                /// Get Category base on  Merchant
                /// 

           //     var categories = _repository.GetCategoryByMerchant("Bergdorf Goodman");


            }
        }

    }
}
