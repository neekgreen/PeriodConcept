using System;
using System.Collections.Generic;
using System.Linq;
using PeriodConcept.Common;

namespace PeriodConcept.Web.Areas.Elastic.Models.Filterable
{
    public class SettingsViewModel
    {
        public int? PageNumber { get; set; }
        public int? ItemCountPerPage { get; set; }
        public string QueryText { get; set; }

        public IEnumerable<Filter> Filters { get; set; }
    }
}