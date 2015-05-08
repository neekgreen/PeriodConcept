using System;
using System.Linq;
using PeriodConcept.Models;

namespace PeriodConcept.Web.Areas.Database.Models
{
    public class PeriodViewModel
    {
        public PeriodViewModel(Period period)
        {
            this.Period = period;
        }

        public Period Period { get; set; }
    }
}