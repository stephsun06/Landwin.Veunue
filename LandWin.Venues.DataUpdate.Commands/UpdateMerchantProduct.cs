using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataUpdate.Commands
{
    public class UpdateMerchantProduct
    {
        public string GroupId { get; set; }
        public string MerchantName { get; set; }
        public string SKU { get; set; }
        public string ID { get; set; }
    }
}
