using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.Domain.Dapper.Entities
{
    public class VenueProduct
    {
        public long Id { get; set; }
        public string PartNumber { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Merchant { get; set; }
        public string MerchantId { get; set; }
        public string Description { get; set; }
        public string ProductURL { get; set; }
        public decimal ReatilPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal ShipFlatRate { get; set; }
        public long CategoryId { get; set; }
        public string CatalogId { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
