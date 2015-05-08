using System;
using System.Linq;

namespace PeriodConcept.Web.Areas.Elastic.Models.Paginable
{
    public class SettingsBindingModel
    {
        public int? PageNumber { get; set; }
        public int? ItemCountPerPage { get; set; }
    }
}