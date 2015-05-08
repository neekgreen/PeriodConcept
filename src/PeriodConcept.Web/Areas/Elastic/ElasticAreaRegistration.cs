using System.Web.Mvc;

namespace PeriodConcept.Web.Areas.Elastic
{
    public class ElasticAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "Elastic"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Elastic_default",
                "Elastic/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PeriodConcept.Web.Areas.Elastic.Controllers" }
            );
        }
    }
}