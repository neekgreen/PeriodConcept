using System;
using System.Web;

namespace PeriodConcept.Web.Configurations
{
    public class StructureMapScopeModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) =>
            {
                StructureMapConfiguration.StructureMapResolver.CreateNestedContainer();
            };

            context.EndRequest += (sender, e) =>
            {
                StructureMapConfiguration.StructureMapResolver.DisposeNestedContainer();
            };
        }
    }
}