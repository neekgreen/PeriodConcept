using System;
using System.Linq;
using System.Web.Mvc;
using MediatR;
using PeriodConcept.Queries;
using PeriodConcept.Web.Areas.Database.Models.Paginable;

namespace PeriodConcept.Web.Areas.Database.Controllers
{
    public class PaginableController : Controller
    {
        private readonly IMediator mediator;

        public PaginableController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ActionResult Index()
        {
            return View(new IndexViewModel { PageNumber = 1, ItemCountPerPage = Constants.ItemCountPerPage });
        }

        public ActionResult IndexPartial(SettingsBindingModel settings)
        {
            var query = new PeriodsPaginableDatabaseQuery
            {
                PageNumber = settings.PageNumber ?? 1,
                ItemCountPerPage = settings.ItemCountPerPage ?? Constants.ItemCountPerPage,
            };

            var paginable = this.mediator.Send(query);
            var model = new IndexViewModel(paginable);

            return PartialView(model);
        }
    }
}