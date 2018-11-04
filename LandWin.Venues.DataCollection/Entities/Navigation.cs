using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Entities
{
    public class Navigation
    {
        public string url { get; set; }
        
        public string previous_page_url { get; set; }

        public string next_page_url { get; set; }
    }
}
