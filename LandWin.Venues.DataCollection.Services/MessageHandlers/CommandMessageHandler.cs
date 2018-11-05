using LandWin.Venues.DataCollection.Commands;
using LandWin.Venues.DataCollection.Repositories;
using LandWin.Venues.DataCollection.Services.Infra;
using LandWin.Venues.DataCollection.Services.ProcessManager;
using LandWin.Venues.Domain.Dapper;
using LandWin.Venues.Domain.Dapper.Repositories;
using log4net;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWin.Venues.DataCollection.Services.MessageHandlers
{
    public class CommandMessageHandler : IMessageHandler<SyncProduct>
    {
        private IDataCollectionManager _dataCollectionManger;


        private static readonly ILog _log = LogManager.GetLogger(typeof(CommandMessageHandler));

        public CommandMessageHandler(IDataCollectionManager dataCollectionManager)
        {

            if (dataCollectionManager == null) throw new ArgumentNullException("dataCollectionManager");


            _dataCollectionManger = dataCollectionManager;
        }

        public void Handle(SyncProduct message)
        {
            _log.DebugFormat("Received Message : Merchant {0}", message.MerchantName);

            _dataCollectionManger.Run(message.MerchantName);

        }
    }

      
}
