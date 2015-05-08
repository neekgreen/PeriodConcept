using System;
using System.Linq;
using StructureMap;

namespace PeriodConcept.Web.Configurations
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}