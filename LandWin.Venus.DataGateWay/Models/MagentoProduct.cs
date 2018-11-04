using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venus.DataGateWay.Models
{
    public class MagentoProduct 
    {
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string Merchant { get; set; }
        public decimal Retail_Price { get; set; }
        public string ImageUrl { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
    }
}
