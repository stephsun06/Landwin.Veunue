using NServiceBus;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandWin.Venues.DataCollection.Web.App_Start
{
    public class BusRegistry : Registry
    {
        public BusRegistry()
        {
            For<IBus>().Singleton().Use(StartBus());
        }

        private static IBus StartBus()
        {
            return NServiceBus.Configure
                .With()
                .DefiningCommandsAs(type =>
                {
                    return type.Namespace == "LandWin.Venues.DataCollection.Commands";
                })

                .DefaultBuilder()
                .XmlSerializer()
                .MsmqTransport()
                .UnicastBus()
                .SendOnly();
        }
    }
}