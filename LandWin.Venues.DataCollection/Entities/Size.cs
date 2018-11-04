using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Entities
{
    public class Size
    {
        public string size { get; set; }
        public string id { get; set; }
        public string merchant_sku { get; set; }
        public string sku { get; set; }
        public string upc { get; set; }
        public bool active { get; set; }
    }
}
