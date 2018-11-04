using MongoDB.Bson.Serialization.Attributes;
using NobelProcera.Framework.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Entities
{
    public class Catalog 
    {
        //[BsonId]
        //public Object Id { get; set; }

        //public DateTime receivedDate { get; set; }
        
        public Metadata metadata { get; set; }

        public Navigation navigation { get; set; }

        public List<Product> products { get; set; }

        public Catalog()
        {
            metadata = new Metadata();
            navigation = new Navigation();
            products = new List<Product>();
        }
    }
}
