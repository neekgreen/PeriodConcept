using System;
using System.Linq;
using PeriodConcept.Models;

namespace PeriodConcept.Web.Models
{
    public class PeriodViewModel
    {
        public PeriodViewModel(Period period)
        {
            this.Period = period;
        }

        public Period Period { get; private set; }
    }
}