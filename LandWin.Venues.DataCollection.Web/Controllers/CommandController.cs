using LandWin.Venues.DataCollection.Commands;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LandWin.Venues.DataCollection.Web.Controllers
{

    [RoutePrefix("api/commands")]
    public class CommandController : ApiController
    {

        private readonly IBus _bus;


        public CommandController(IBus bus)
        {
            if (bus == null) throw new ArgumentNullException("bus");

            _bus = bus;
        }

        [HttpGet]
        [Route("SyncProduct/{merchant}")]
        public void SyncProduct(string merchant)
        {
            _bus.Send(new SyncProduct()
                {
                    MerchantName = merchant
                });
                 
        }
    }
}
