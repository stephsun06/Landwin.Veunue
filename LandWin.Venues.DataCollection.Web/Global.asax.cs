using LandWin.Venues.DataCollection.Web.App_Start;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LandWin.Venues.DataCollection.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Container(x => x.Scan(s =>
            {
                s.LookForRegistries();
                s.TheCallingAssembly();

            }));

            var dependencyResolver = new StructureMapDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}
