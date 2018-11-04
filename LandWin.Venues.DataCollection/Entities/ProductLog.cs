using NobelProcera.Framework.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Entities
{
    public class ProductLog : Entity
    {
        public DateTime ReceivdDate { get; set; }
        public string MerchantName { get; set; }
        public string GroupId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
