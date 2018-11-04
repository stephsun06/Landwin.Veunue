using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venus.DataGateWay.Models
{
    public class ProductInfo
    {
        public string PartNumber { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Merchant { get; set; }
        public string Description { get; set; }
        public long ColorId { get; set; }
        public string Color { get; set; }
        public decimal Retail_Price { get; set; }

    }
}
