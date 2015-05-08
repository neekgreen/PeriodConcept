using System;
using System.Linq;
using System.Web.Mvc;
using MediatR;
using PeriodConcept.Queries;
using PeriodConcept.Web.Areas.Elastic.Models.Searchable;

namespace PeriodConcept.Web.Areas.Elastic.Controllers
{
    public class SearchableController : Controller
    {
        private readonly IMediator mediator;

        public SearchableController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ActionResult Index()
        {
            return View(new IndexViewModel { PageNumber = 1, ItemCountPerPage = Constants.ItemCountPerPage });
        }

        public ActionResult IndexPartial(SettingsBindingModel settings)
        {
            var query = new PeriodsSearchableElasticQuery
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