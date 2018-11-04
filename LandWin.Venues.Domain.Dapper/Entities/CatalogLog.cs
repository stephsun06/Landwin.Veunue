using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.Domain.Dapper.Entities
{
    public class CatalogLog
    {
        public string Id { get; set; }
        public DateTime ReceivedDate { get; set; }
        public bool IsLoaded { get; set; }
        public string MerchantName { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public string CatalogId { get; set; }
        public string GroupId { get; set; }
     
    }
}
