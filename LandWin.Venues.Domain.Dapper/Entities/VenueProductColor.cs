

namespace LandWin.Venues.Domain.Dapper.Entities
{
    public class VenueProductColor
    {
        public long Id { get; set; }
        public string ColorName { get; set; }
        public string ImageUrl { get; set; }
        public long ProductId { get; set; }
        public decimal RetailPrice { get; set; }
        public string FileName { get; set; }
        
    }
}
