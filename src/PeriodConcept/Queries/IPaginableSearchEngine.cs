using System;
using System.Linq;
using PeriodConcept.Common;
using PeriodConcept.Models;

namespace PeriodConcept.Queries
{
    public interface IPaginableSearchEngine
    {
        IPaginable<Period> Search(string queryText, int pageNumber, int itemCountPerPage);
    }
}