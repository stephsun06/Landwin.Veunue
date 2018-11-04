using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venus.DataGateWay.Models
{
    public class ImageUrl
    {
        public string Brand { get; set; }
        public long ColorId { get; set; }
        public string Url { get; set; }
        public byte[] ImageByte { get; set; }

    }
}
