using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using PeriodConcept.Web.Configurations;
using StructureMap;

[assembly: PreApplicationStartMethod(typeof(StructureMapConfiguration), "Configure")]

namespace PeriodConcept.Web.Configurations
{
    public static class StructureMapConfiguration
    {
        public static StructureMapDependencyResolver StructureMapResolver { get; private set; }

        public static void Configure()
        {
            IContainer container = IoC.Initialize();

            StructureMapResolver = new StructureMapDependencyResolver(container);
            DependencyResolver.SetResolver(StructureMapResolver);

            //# Add our custom httpmodule to the ASPNET pipeline.
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            //# Initialize Common Service Locator.
            var serviceLocatorProvider = new ServiceLocatorProvider(() => StructureMapResolver);
            container.Configure(cfg => cfg.For<ServiceLocatorProvider>().Use(serviceLocatorProvider));

            ServiceLocator.SetLocatorProvider(serviceLocatorProvider);
        }
    }
}