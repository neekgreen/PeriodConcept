using System;
using System.Linq;
using MediatR;
using PeriodConcept.Common;
using PeriodConcept.EntityFramework;
using PeriodConcept.Models;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Web.Pipeline;
using PeriodConcept.Elastic;

namespace PeriodConcept.Web.Configurations
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();

                scan.AssemblyContainingType<IMediator>();
                scan.AssemblyContainingType<IPaginable>();
                scan.AssemblyContainingType<CommonDbContext>();
                scan.AssemblyContainingType<PaginableSearchEngine>();

                scan.With(new ControllerConvention());

                //# MediatR configuration.
                scan.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));

                For<ICommonDbContext>().Use(() => new CommonDbContext()).LifecycleIs<HybridLifecycle>();

                scan.WithDefaultConventions();

                For<IMediator>().Use<Mediator>();
            });
        }
    }
}