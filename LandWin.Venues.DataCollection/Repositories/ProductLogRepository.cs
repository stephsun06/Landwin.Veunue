using LandWin.Venues.DataCollection.Entities;
using NobelProcera.Framework.MongoDB;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LandWin.Venues.DataCollection.Repositories
{
    public class ProductLogRepository : MongoRepository<ProductLog>, IProductLogRepository
    {

        public ProductLogRepository(IMongoUnitOfWork unitofwork) : base(unitofwork, "ProductLog") { }


        public void Delete(string merchant)
        {
            Collection.DeleteOneAsync(Filter.Eq(x => x.MerchantName, merchant));
        }

        public IEnumerable<ProductLog> GetCatalog(string groupId)
        {
            return Collection.FindSync(Filter.Eq(x => x.Id, groupId)).ToList();
        }

        public ProductLog GetProductLog(string id)
        {
            return Collection.FindSync(Filter.Eq(x => x.Id, id)).FirstOrDefault();
        }

        public ProductLog InsertLog(ProductLog log)
        {
             Collection.InsertOne(log);

            return log;
        }
    }
}
