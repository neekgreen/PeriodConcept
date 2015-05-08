using System;
using System.Linq;
using System.Web.Mvc;
using PeriodConcept.Common;
using PeriodConcept.Models;
using PeriodConcept.Web.Models;

namespace PeriodConcept.Web.Areas.Elastic.Models.Filterable
{
    public class IndexViewModel : IFilterableViewModel, ISearchableViewModel, IPaginableViewModel
    {
        public IndexViewModel()
        {
            this.PageNumber = 1;
            this.ItemCountPerPage = Constants.ItemCountPerPage;

            this.ItemCountPerPageList = new SelectList(Constants.ItemCountPerPageValues);
        }

        public IndexViewModel(IFilterable<Period> filterable, string queryText)
            : this()
        {
            this.QueryText = queryText;
            this.Periods =
                new StaticFilterable<PeriodViewModel>(
                    filterable.Select(period => new PeriodViewModel(period)),
                    filterable.Filters,
                    filterable.PageNumber,
                    filterable.ItemCountPerPage,
                    filterable.TotalItemCount);

            this.PageNumber = filterable.PageNumber;
            this.ItemCountPerPage = filterable.ItemCountPerPage;

            this.ItemCountPerPageList = new SelectList(Constants.ItemCountPerPageValues, filterable.ItemCountPerPage);
        }

        public int PageNumber { get; set; }
        public int ItemCountPerPage { get; set; }
        public string QueryText { get; set; }

        public IFilterable<PeriodViewModel> Periods { get; set; }

        public SelectList ItemCountPerPageList { get; set; }
    }
}