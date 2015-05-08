using System;
using System.Linq;
using System.Web.Mvc;
using PeriodConcept.Common;
using PeriodConcept.Models;
using PeriodConcept.Web.Models;

namespace PeriodConcept.Web.Areas.Elastic.Models.Searchable
{
    public class IndexViewModel : ISearchableViewModel, IPaginableViewModel
    {
        public IndexViewModel()
        {
            this.PageNumber = 1;
            this.ItemCountPerPage = Constants.ItemCountPerPage;

            this.ItemCountPerPageList = new SelectList(Constants.ItemCountPerPageValues);
        }

        public IndexViewModel(IPaginable<Period> paginable, string queryText)
            : this()
        {
            this.QueryText = queryText;
            this.Periods =
                new StaticPaginable<PeriodViewModel>(
                    paginable.Select(period => new PeriodViewModel(period)),
                    paginable.PageNumber,
                    paginable.ItemCountPerPage,
                    paginable.TotalItemCount);

            this.PageNumber = paginable.PageNumber;
            this.ItemCountPerPage = paginable.ItemCountPerPage;

            this.ItemCountPerPageList = new SelectList(Constants.ItemCountPerPageValues, paginable.ItemCountPerPage);
        }

        public int PageNumber { get; set; }
        public int ItemCountPerPage { get; set; }
        public string QueryText { get; set; }

        public IPaginable<PeriodViewModel> Periods { get; set; }

        public SelectList ItemCountPerPageList { get; set; }
    }
}