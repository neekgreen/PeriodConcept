using System;
using System.Linq;

namespace PeriodConcept.Common
{
    public class FilterItem
    {
        public Filter Filter { get; set; }
        public string Value { get; set; }

        public int ItemCount { get; set; }
    }
}