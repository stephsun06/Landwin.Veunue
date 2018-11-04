using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Entities
{
    public class Color
    {
        public string color { get; set; }
        public decimal retail_price { get; set; }
        public decimal sales_price { get; set; }
  
        public string[] image { get; set; }

        public List<Size> sizes { get; set; }

        public Color()
        {
            sizes = new List<Size>();
        }
    }
}
