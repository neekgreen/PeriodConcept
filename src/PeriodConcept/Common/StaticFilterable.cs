using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodConcept.Common
{
    public class StaticFilterable<T> : StaticPaginable<T>, IFilterable<T>
    {
        private readonly IEnumerable<Filter> filters;

        public StaticFilterable(IEnumerable<T> subset, IEnumerable<Filter> filters, int pageNumber, int itemCountPerPage, int totalItemCount)
            : base(subset, pageNumber, itemCountPerPage, totalItemCount)
        {
            this.filters = filters;
        }

        public IEnumerable<Filter> Filters { get { return this.filters; } }
    }
}