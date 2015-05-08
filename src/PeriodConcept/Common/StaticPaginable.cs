using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeriodConcept.Common
{
    public class StaticPaginable<T> : IPaginable<T>
    {
        private readonly List<T> innerList = new List<T>();

        public StaticPaginable(IEnumerable<T> subset, int pageNumber, int itemCountPerPage, int totalItemCount)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
            if (itemCountPerPage < 1)
                throw new ArgumentOutOfRangeException("ItemCountPerPage", itemCountPerPage, "ItemCountPerPage cannot be less than 1.");

            this.TotalItemCount = totalItemCount;
            this.PageNumber = pageNumber;
            this.ItemCountPerPage = itemCountPerPage;

            this.innerList.AddRange(subset);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the IPaginable&lt;T&gt;.
        /// </summary>
        /// <returns>A IPaginable&lt;T&gt;.Enumerator for the IPaginable&lt;T&gt;.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the IPaginable&lt;T&gt;.
        /// </summary>
        /// <returns>A IPaginable&lt;T&gt;.Enumerator for the IPaginable&lt;T&gt;.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        /// <summary>
        /// Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        /// Total number of objects contained within the superset.
        /// </value>
        public int TotalItemCount { get; private set; }

        /// <summary>
        /// One-based index of this subset within the superset.
        /// </summary>
        /// <value>
        /// One-based index of this subset within the superset.
        /// </value>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        /// Total number of objects contained within the superset.
        /// </value>
        public int ItemCountPerPage { get; private set; }

        ///<summary>
        /// Gets the element at the specified index.
        ///</summary>
        ///<param name = "index">The zero-based index of the element to get.</param>
        public T this[int index]
        {
            get { return innerList[index]; }
        }
        /// <summary>
        /// Gets the number of elements contained on this page.
        /// </summary>
        public int Count
        {
            get { return innerList.Count; }
        }

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


        /// <summary>
        /// Returns true if this is the first subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is the first subset within the superset.
        /// </value>
        public bool IsFirstPage { get { return PageNumber == 1; } }

        /// <summary>
        /// Returns true if this is the last subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is the last subset within the superset.
        /// </value>
        public bool IsLastPage { get { return PageNumber >= TotalPageCount; } }

        /// <summary>
        /// Returns true if this is NOT the first subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is NOT the first subset within the superset.
        /// </value>
        public bool HasPreviousPage { get { return PageNumber > 1; } }

        /// <summary>
        /// Returns true if this is NOT the last subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is NOT the last subset within the superset.
        /// </value>
        public bool HasNextPage { get { return PageNumber < TotalPageCount; } }
    }
}