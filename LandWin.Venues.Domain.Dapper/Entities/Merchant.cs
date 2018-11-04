using System;

namespace LandWin.Venues.Domain.Dapper.Entities
{
    public class Merchant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
