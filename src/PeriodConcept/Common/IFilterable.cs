using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodConcept.Common
{
    public interface IFilterable<T> : IPaginable<T>
    {
        IEnumerable<Filter> Filters { get; }
    }
}