using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeriodConcept.Common
{
    public class Paginable<T> : IPaginable<T>
    {
        private readonly List<T> innerList = new List<T>();

        public Paginable(IQueryable<T> superset, int pageNumber, int itemCountPerPage)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
            if (itemCountPerPage < 1)
                throw new ArgumentOutOfRangeException("ItemCountPerPage", itemCountPerPage, "ItemCountPerPage cannot be less than 1.");

            this.TotalItemCount = superset == null ? 0 : superset.Count();
            this.PageNumber = pageNumber;
            this.ItemCountPerPage = itemCountPerPage;

            if (superset != null && TotalItemCount > 0)
                innerList.AddRange(pageNumber == 1
                                   ? superset.Skip(0).Take(ItemCountPerPage).ToList()
                                   : superset.Skip((pageNumber - 1) * ItemCountPerPage).Take(ItemCountPerPage).ToList());
        }

        public Paginable(IEnumerable<T> superset, int pageNumber, int itemCountPerPage)
            : this(superset.AsQueryable(), pageNumber, itemCountPerPage)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        public int TotalItemCount { get; private set; }

        public int PageNumber { get; private set; }

        public int ItemCountPerPage { get; private set; }

        public T this[int index] { get { return innerList[index]; } }

        public int Count { get { return innerList.Count; } }

        public int TotalPageCount
        {
            get
            {
                return
                    TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)this.ItemCountPerPage)
                        : 0;
            }
        }

        public bool IsFirstPage { get { return PageNumber == 1; } }

        public bool IsLastPage { get { return PageNumber >= TotalPageCount; } }

        public bool HasPreviousPage { get { return PageNumber > 1; } }

        public bool HasNextPage { get { return PageNumber < TotalPageCount; } }
    }
}