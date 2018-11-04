using StructureMap;
using System;
using System.Web.Http.Dependencies;

namespace LandWin.Venues.DataCollection.Web.App_Start
{
    public class StructureMapDependencyResolver : StructureMapDependencyScope, IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = container.GetNestedContainer();
            return new StructureMapDependencyScope(childContainer);
        }
    }
}