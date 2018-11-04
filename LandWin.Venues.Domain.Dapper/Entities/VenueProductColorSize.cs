using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.Domain.Dapper.Entities
{
    public class VenueProductColorSize
    {
        public long Id { get; set; }
        public long ColorId { get; set; }
        public string UPC { get; set; }
        public string SizeName { get; set; }
        public bool OnSale { get; set; }
        public string SKU { get; set; }
        public string MerchantSKU { get; set; }
    }
}
