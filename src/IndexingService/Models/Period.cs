using System;
using System.Linq;

namespace IndexingService.Models
{
    public class Period
    {
        public int PeriodID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public int YearValue { get; set; }
        public int MonthValue { get; set; }

        public string MonthName { get; set; }
        public int DayOfMonth { get; set; }
        public int DayOfYear { get; set; }
        public int WeekOfYear { get; set; }
        public string WeekdayName { get; set; }
    }
}