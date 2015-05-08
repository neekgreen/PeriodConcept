using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace PeriodConcept.Web.Configurations
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if ((requestContext == null) || (controllerType == null))
                    return null;

                return (Controller)StructureMapConfiguration.StructureMapResolver.Container.GetInstance(controllerType);
            }
            catch (StructureMapException)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }            
        }
    }
}