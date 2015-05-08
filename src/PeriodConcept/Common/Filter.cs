using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodConcept.Common
{
    public class Filter
    {
        public Filter()
        {
            this.Items = new List<FilterItem>();
        }

        public string CommonName { get; set; }
        public IList<FilterItem> Items { get; set; }
    }
}