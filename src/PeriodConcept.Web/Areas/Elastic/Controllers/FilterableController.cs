using System;
using System.Linq;
using System.Web.Mvc;
using MediatR;
using PeriodConcept.Queries;
using PeriodConcept.Web.Areas.Elastic.Models.Filterable;

namespace PeriodConcept.Web.Areas.Elastic.Controllers
{
    public class FilterableController : Controller
    {
        private readonly IMediator mediator;

        public FilterableController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ActionResult Index()
        {
            return View(new IndexViewModel { PageNumber = 1, ItemCountPerPage = Constants.ItemCountPerPage });
        }

        public ActionResult IndexPartial(SettingsViewModel settings)
        {
            var query = new PeriodsFilterableElasticQuery
            {
                PageNumber = settings.PageNumber ?? 1,
                ItemCountPerPage = settings.ItemCountPerPage ?? Constants.ItemCountPerPage,
                QueryText = settings.QueryText,
            };

            var paginable = this.mediator.Send(query);
            var model = new IndexViewModel(paginable, settings.QueryText);

            return PartialView(model);
        }
    }
}