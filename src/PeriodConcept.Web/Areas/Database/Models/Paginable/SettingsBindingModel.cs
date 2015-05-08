using System;
using System.Linq;

namespace PeriodConcept.Web.Areas.Database.Models.Paginable
{
    public class SettingsBindingModel
    {
        public int? PageNumber { get; set; }
        public int? ItemCountPerPage { get; set; }
    }
}