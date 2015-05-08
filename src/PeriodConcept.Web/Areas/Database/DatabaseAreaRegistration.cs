using System.Web.Mvc;

namespace PeriodConcept.Web.Areas.Database
{
    public class DatabaseAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "Database"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Database_default",
                "Database/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PeriodConcept.Web.Areas.Database.Controllers" }
            );
        }
    }
}