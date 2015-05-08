using System;
using System.Linq;

namespace PeriodConcept.Common
{
    public static class PaginableExtensions
    {
        public static IPaginable<T> ToPaginable<T>(this IQueryable<T> queryable, int pageNumber, int itemCountPerPage)
        {
            return new Paginable<T>(queryable, pageNumber, itemCountPerPage);
        }
    }
}