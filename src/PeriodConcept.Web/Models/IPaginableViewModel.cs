using System;
using System.Linq;
using System.Web.Mvc;

namespace PeriodConcept.Web.Models
{
    public interface IPaginableViewModel
    {
        int PageNumber { get; set; }
        int ItemCountPerPage { get; set; }

        SelectList ItemCountPerPageList { get; set; }
    }
}